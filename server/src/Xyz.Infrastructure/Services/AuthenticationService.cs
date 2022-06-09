using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Identity;
using Xyz.Core.Entities.Tenant;
using Xyz.Core.Models;
using Xyz.Core.Models.Configuration;
using Xyz.Core.Interfaces;
using Xyz.Core.Dtos;

using Xyz.Infrastructure.Data;

using Xyz.Multitenancy.Data;
using Xyz.Multitenancy.Multitenancy;

namespace Xyz.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IOptions<TenantConnectionSettings> _tenantConnectionSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MultitenancyDbContext _multitenancyDbContext;
        private readonly ITokenService _tokenService;
        private readonly ITenantAccessor<Tenant> _tenantAccessor;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IEmailingService _emailingService;


        public AuthenticationService(
            ILogger<AuthenticationService> logger, 
            IOptions<TenantConnectionSettings> tenantConnectionSettings,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ApplicationDbContext applicationDbContext,
            MultitenancyDbContext multitenancyDbContext,
            ITokenService tokenService,
            ITenantAccessor<Tenant> tenanatAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEmailingService emailingService)
        {
            this._logger = logger;
            this._tenantConnectionSettings = tenantConnectionSettings;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._applicationDbContext = applicationDbContext;
            this._multitenancyDbContext = multitenancyDbContext;
            this._tokenService = tokenService;
            this._tenantAccessor = tenanatAccessor;
            this._passwordHasher = passwordHasher;
            this._emailingService = emailingService;
        }

        public async Task<AuthenticatedUser> Login(Credentials credentials)
        {
            var tenant = this._tenantAccessor.Tenant;

            if (tenant == null || !tenant.IsActive || !tenant.IsActive)
            {
                throw new Exception("Account is still being setup or is inactive! Please try again later!");
            }

            var user = await this._userManager.FindByNameAsync(credentials.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, credentials.Password))
            {                
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(MultiTenantConstants.TenantClaim, tenant.Guid)
                };

                var userRoles = await this._userManager.GetRolesAsync(user);

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = await this._tokenService.CreateJwtSecurityToken(authClaims);

                var savedRefreshToken = await this._applicationDbContext.RefreshTokens
                    .Where(t => t.UserId.ToString() == user.Id.ToString() && !t.IsBlacklisted)
                    .FirstOrDefaultAsync();

                if (savedRefreshToken == null)
                {
                    savedRefreshToken = new RefreshToken { UserId = user.Id };
                    this._applicationDbContext.RefreshTokens.Add(savedRefreshToken);
                    await this._applicationDbContext.SaveChangesAsync();
                }

                return new AuthenticatedUser
                {
                    Status = AuthenticatedStatus.AUTHENTICATED,
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = savedRefreshToken.Token.ToString()
                };
            }
            
            return null;
        }

        public async Task<object> Register(Registration registration)
        {
            using var transaction = this._multitenancyDbContext.Database.BeginTransaction();

            try 
            {
                var tenant = await this._HandleMultitenancyTenatSetup(registration);
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

        public async Task<object> ForgotPassword()
        {
            var emailRequest = new EmailRequest
            {
                To = "jmw5598@gmail.com",
                Subject = "Testing",
                Body = "Testing Body"
            };
            await this._emailingService.SendEmailAsync(emailRequest);
            return await Task.FromResult(new {});
        }

        public async Task<object> ChangePassword()
        {
            return await Task.FromResult(new {});
        }

        public async Task<AuthenticatedUser> RefreshAccessToken(RefreshTokenRequest refreshTokenRequest)
        {
            try 
            {
                var isAccessTokenValid = await this._tokenService
                    .IsValidJwtSecurityToken(refreshTokenRequest.AccessToken);

                if (!isAccessTokenValid)
                {
                    throw new Exception("Unable to refresh access token, the supplied access token was invalid!");
                }

                var savedRefreshToken = await this._applicationDbContext.RefreshTokens
                    .Where(t => t.Token.ToString() == refreshTokenRequest.RefreshToken && !t.IsBlacklisted)
                    .FirstOrDefaultAsync();

                if (savedRefreshToken == null)
                {
                    throw new Exception("Unable to refresh access token, the supplied refresh token was invalid!");
                }

                var decodedAccessToken = await this._tokenService.DecodeJwtSecurityToken(refreshTokenRequest.AccessToken);

                if (decodedAccessToken == null)
                {
                    throw new Exception("Unable to refresh access token, decoding existing token failed!");
                }

                var authClaims = decodedAccessToken.Claims.ToList();

                var token = await this._tokenService.CreateJwtSecurityToken(authClaims);

                return new AuthenticatedUser
                {
                    Status = AuthenticatedStatus.AUTHENTICATED,
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = savedRefreshToken.Token.ToString()
                };
            }
            catch (Exception ex)
            {
                var errorMessage = "Error refreshing access token!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                throw;
            }
        }

        public async Task<Page<TenantDto>> SearchCompanies(BasicQuerySearchFilter filter, PageRequest pageRequest)
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
                var erroMessage = "Error setting up tenant databse!";
                this._logger.LogError(erroMessage, registration);
                throw;
            }
        }

        private async Task<Tenant> _HandleMultitenancyTenatSetup(Registration registration)
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