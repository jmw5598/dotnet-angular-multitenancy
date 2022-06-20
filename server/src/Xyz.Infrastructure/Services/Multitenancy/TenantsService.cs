using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using Xyz.Core.Interfaces.Multitenancy;
using Xyz.Core.Dtos.Multitenancy;
using Xyz.Core.Models.Multitenancy;
using Xyz.Core.Models.Tenants;
using Xyz.Multitenancy.Data;

using Xyz.Infrastructure.Data;

namespace Xyz.Infrastructure.Services.Multitenancy
{
    public class TenantsService : ITenantsService
    {
        private readonly ILogger<TenantsService> _logger;
        private readonly MultitenancyDbContext _multitenancyDbContext;
        private readonly ApplicationDbContext _applicationDbContext;

        public TenantsService(
            ILogger<TenantsService> logger, 
            MultitenancyDbContext multitenancyDbContext,
            ApplicationDbContext applicationDbContext)
        {
            this._logger = logger;
            this._multitenancyDbContext = multitenancyDbContext;
            this._applicationDbContext = applicationDbContext;
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
    }
}