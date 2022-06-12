using Xyz.Core.Dtos;
using Xyz.Core.Models;

namespace Xyz.Core.Interfaces
{
    public interface ITenantsService
    {
        public Task<TenantDto> FindTenantFromSubdomainAsync(string subdomain);
        public Task<TenantStatistics> GetTenantStatisticsAsync(string tenantId);
    }
}