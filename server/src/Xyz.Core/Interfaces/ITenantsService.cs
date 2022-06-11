using Xyz.Core.Dtos;

namespace Xyz.Core.Interfaces
{
    public interface ITenantsService
    {
        public Task<TenantDto> FindTenantFromSubdomainAsync(string subdomain);
    }
}