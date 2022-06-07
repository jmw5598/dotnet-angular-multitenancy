using Xyz.Core.Dtos;

namespace Xyz.Core.Interfaces
{
    public interface ITenantsService
    {
        public Task<TenantDto> FindTenantFromSubdomain(string subdomain);
    }
}