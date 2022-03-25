using Xyz.Core.Entities.Multitenancy;

namespace Xyz.Multitenancy.Multitenancy
{
    public interface ITenantStore<T> where T : Tenant
    {
        Task<T> GetTenantAsync(string domainName, string ipAddress, string name);
    }
}
