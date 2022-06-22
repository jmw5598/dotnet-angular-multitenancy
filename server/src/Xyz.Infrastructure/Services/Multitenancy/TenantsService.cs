using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Xyz.Core.Interfaces.Multitenancy;
using Xyz.Core.Dtos.Multitenancy;
using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Tenants;
using Xyz.Core.Entities.Identity;
using Xyz.Core.Models;
using Xyz.Core.Models.Multitenancy;
using Xyz.Core.Models.Tenants;
using Xyz.Core.Models.Configuration;
using Xyz.Core.Models.SearchFilters;
using Xyz.Core.Models.Paging;
using Xyz.Multitenancy.Data;

using Xyz.Infrastructure.Data;

namespace Xyz.Infrastructure.Services.Multitenancy
{
    public class TenantsService : ITenantsService
    {
        private readonly IOptions<TenantConnectionSettings> _tenantConnectionSettings;
        private readonly ILogger<TenantsService> _logger;
        private readonly MultitenancyDbContext _multitenancyDbContext;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public TenantsService(
            ILogger<TenantsService> logger, 
            MultitenancyDbContext multitenancyDbContext,
            ApplicationDbContext applicationDbContext,
            IOptions<TenantConnectionSettings> tenantConnectionSettings,
            IPasswordHasher<ApplicationUser> passwordHasher)
        {
            this._logger = logger;
            this._multitenancyDbContext = multitenancyDbContext;
            this._applicationDbContext = applicationDbContext;
            this._tenantConnectionSettings = tenantConnectionSettings;
            this._passwordHasher = passwordHasher;
        }


        public async Task<TenantDto> FindTenantFromSubdomainAsync(string subdomain)
        {
            try
            {
                var tenant = await this._multitenancyDbContext.Tenants
                    .Include(tenant => tenant.Company)
                    .Include(tenant => tenant.TenantPlan)
                    .ThenInclude(tenantPlan => tenantPlan.Plan)
                    .Where(tenant => tenant.Name.Trim().ToLower() == subdomain.Trim().ToLower())
                    .FirstOrDefaultAsync();

                if (tenant == null)
                {
                    throw new Exception("Error finding tenant by subdomain!");
                }

                return tenant.ToDto();
            }
            catch (Exception ex)
            {
                var erroMessage = "Error finding tenant subdomain!";
                this._logger.LogError(erroMessage, new { Exception = ex, Subdomain = subdomain });
                throw;
            }
        }

        public async Task<TenantStatistics> GetTenantStatisticsAsync(string tenantId)
        {
            try
            {
                var tenant = await this._multitenancyDbContext.Tenants
                    .Include(tenant => tenant.Company)
                    .Include(tenant => tenant.TenantPlan)
                    .ThenInclude(tp => tp.Plan)
                    .Where(tenant => tenant.Id.ToString() == tenantId)
                    .Select(tenant => tenant.ToDto())
                    .FirstOrDefaultAsync();

                if (tenant == null)
                {
                    throw new Exception("Error finding tenant with the supplied ID!");
                }

                var userAccountsCount = await this._applicationDbContext.Users
                    .Include(user => user.UserRoles)
                    .Where(user => !user.UserRoles.Any(ur => ur.Role.Name == Roles.ADMIN))
                    .CountAsync();

                return new TenantStatistics
                {
                    Tenant = tenant,
                    UserAccountsCount = userAccountsCount
                };
            }
            catch (Exception ex)
            {
                var erroMessage = "Error getting tenant statistics!";
                this._logger.LogError(erroMessage, new { Exception = ex, TenantId = tenantId });
                throw;
            }
        }

        public async Task<object> RegisterAsync(Registration registration)
        {
            using var transaction = this._multitenancyDbContext.Database.BeginTransaction();

            try 
            {
                var tenant = await this._HandleMultitenancyTenantSetup(registration);
                await this._HandleTenantDatabaseSetup(registration, tenant.ConnectionString);

                transaction.Commit();

                return new ResponseMessage
                {
                    Status = ResponseStatus.SUCCESS,
                    Message = "Your account was create!\n  Please check your email for a confirmation!"
                };
            }
            catch (Exception e)
            {
                transaction.Rollback();
                this._logger.LogError("Error registering new account!", e);
                throw new Exception("Error registering new account!");
            }
        }

        public async Task<Page<TenantDto>> SearchCompaniesAsync(BasicQuerySearchFilter filter, PageRequest pageRequest)
        {
            try
            {
                IQueryable<Tenant> query = this._multitenancyDbContext.Tenants.Include(t => t.Company)
                    .Where(tenant => tenant.DisplayName.Trim().ToLower().IndexOf("localhost") == -1);

                if (filter?.Query != null)
                {
                    var queryTerm = filter.Query.Trim().ToLower();
                    query = query
                        .Where(tenant => tenant.Company.Name.ToLower().Contains(queryTerm));
                }
                    
                var tenantsSource = query.Select(tenant => tenant.ToDto());

                return await Page<TenantDto>.From(tenantsSource, pageRequest);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error searching companies!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                throw;
            }
        }

        private async Task _HandleTenantDatabaseSetup(Registration registration, string connectionString)
        {
            // Create application db context and scaffold new database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention()
                .Options;

            using var newTenantDbContext = new ApplicationDbContext(options);
            newTenantDbContext.Database.Migrate();

            var transaction = newTenantDbContext.Database.BeginTransaction();
            
            try
            {
                var modulePermissions = await newTenantDbContext.ModulePermissions
                    .Include(mp => mp.Permissions)
                    .ToListAsync();

                if (modulePermissions != null)
                {
                    registration.User.UserModulePermissions = 
                        this._GenerateRootAdminUserModulePermissions(registration.User.Id, modulePermissions);
                }

                registration.User.Profile = registration.Profile;

                var hashedPassword = _passwordHasher.HashPassword(registration.User, registration.RawPassword);
                registration.User.SecurityStamp = Guid.NewGuid().ToString();
                registration.User.PasswordHash = hashedPassword;

                newTenantDbContext.Users.Add(registration.User);

                // Add Admin role to root user
                var rootUserAdminRole = await newTenantDbContext.Roles
                    .Where(role => role.Name == Roles.ADMIN)
                    .FirstOrDefaultAsync();
                
                if (rootUserAdminRole != null)
                {
                    newTenantDbContext.UserRoles.Add(new ApplicationUserRole
                    {
                        UserId = registration.User.Id,
                        RoleId = rootUserAdminRole.Id
                    });
                }

                newTenantDbContext.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                var errorMessage = "Error setting up tenant databse!";
                var loggerData = new { Exception = ex.Message, Registration = registration };
                this._logger.LogError(errorMessage, loggerData);
                throw;
            }
        }

        private async Task<Tenant> _HandleMultitenancyTenantSetup(Registration registration)
        {
            var plan = this._multitenancyDbContext.Plans.Find(registration.Plan.Id);

            if (plan == null)
            {
                throw new Exception("Error finding selected plan!");
            }

            var tenantGuid = Guid.NewGuid();

            var tenant = new Tenant
            {
                Name = registration.Subdomain,
                DisplayName = registration.Company.Name,
                Guid = tenantGuid.ToString(),
                Company = registration.Company,
                IsActive = true,
                IsConfigured = true,
                TenantPlan = new TenantPlan
                {
                    MaxUserCount = plan.MaxUserCount,
                    PlanId = plan.Id,
                    Price = plan.Price,
                    RenewalRate = plan.RenewalRate
                },
                PaymentDetails = registration.PaymentDetails != null ? registration.PaymentDetails : null,
                DomainNames = registration.Subdomain,
                ConnectionString = this._GenerateDefaultTenantConnectionString(tenantGuid.ToString()),
                IpAddresses = ""
            };

            this._multitenancyDbContext.Tenants.Add(tenant);
            await this._multitenancyDbContext.SaveChangesAsync();

            return tenant;
        }

        private ICollection<UserModulePermission> _GenerateRootAdminUserModulePermissions(
            Guid UserId, ICollection<ModulePermission> modulePermissions)
        {
            return modulePermissions.Select(mp => {
                var userModulePermissionId = Guid.NewGuid();
                return new UserModulePermission
                {
                    Id = userModulePermissionId,
                    HasAccess = true,
                    ModulePermissionId = mp.Id,
                    UserId = UserId,
                    UserPermissions = mp.Permissions.Select(p =>
                        new UserPermission
                        {
                            CanCreate = true,
                            CanRead = true,
                            CanUpdate = true,
                            CanDelete = true,
                            PermissionId = p.Id,
                            UserModulePermissionId = userModulePermissionId
                        }
                    ).ToList()
                };
            }).ToList();
        }

        private string _GenerateDefaultTenantConnectionString(string database)
        {
            var connectionSettings = this._tenantConnectionSettings.Value;
            var server = connectionSettings.Server;
            var port = connectionSettings.Port;
            var user = connectionSettings.UserId;
            var password = connectionSettings.Password;
            return $@"Server={server};Port={port};Database={database};User Id={user};Password={password};";

        }
    }
}
