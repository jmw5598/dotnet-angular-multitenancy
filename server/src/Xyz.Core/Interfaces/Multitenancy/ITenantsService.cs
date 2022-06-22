using Xyz.Core.Dtos.Multitenancy;
using Xyz.Core.Models;
using Xyz.Core.Models.Paging;
using Xyz.Core.Models.SearchFilters;
using Xyz.Core.Models.Multitenancy;

namespace Xyz.Core.Interfaces.Multitenancy
{
    public interface ITenantsService
    {
        public Task<TenantDto> FindTenantFromSubdomainAsync(string subdomain);
        public Task<TenantStatistics> GetTenantStatisticsAsync(string tenantId);
        public Task<object> RegisterAsync(Registration registration);
        public Task<Page<TenantDto>> SearchCompaniesAsync(BasicQuerySearchFilter filter, PageRequest pageRequest);
    }
}