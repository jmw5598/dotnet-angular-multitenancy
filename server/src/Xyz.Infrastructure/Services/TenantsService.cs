using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using Xyz.Core.Interfaces;
using Xyz.Core.Dtos;
using Xyz.Multitenancy.Data;

namespace Xyz.Infrastructure.Services
{
    public class TenantsService : ITenantsService
    {
        private readonly ILogger<TenantsService> _logger;
        private readonly MultitenancyDbContext _multitenancyDbContext;

        public TenantsService(ILogger<TenantsService> logger, MultitenancyDbContext multitenancyDbContext)
        {
            this._logger = logger;
            this._multitenancyDbContext = multitenancyDbContext;
        }


        public async Task<TenantDto> FindTenantFromSubdomain(string subdomain)
        {
            try
            {
                var tenant = await this._multitenancyDbContext.Tenants
                    .Include(tenant => tenant.Company)
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
    }
}