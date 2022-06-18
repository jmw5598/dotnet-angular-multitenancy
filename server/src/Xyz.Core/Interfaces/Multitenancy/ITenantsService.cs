using Xyz.Core.Dtos.Multitenancy;
using Xyz.Core.Models.Multitenancy;

namespace Xyz.Core.Interfaces.Multitenancy
{
    public interface ITenantsService
    {
        public Task<TenantDto> FindTenantFromSubdomainAsync(string subdomain);
        public Task<TenantStatistics> GetTenantStatisticsAsync(string tenantId);
    }
}