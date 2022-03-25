using Xyz.Core.Entities.Multitenancy;

namespace Xyz.Multitenancy.Multitenancy
{
    public interface ITenantAccessor<T> where T : Tenant
    {
        T Tenant { get; }
    }
}
