using Xyz.Core.Entities.Multitenancy;

namespace Xyz.Multitenancy.Multitenancy
{
    public class MultitenantConfiguration
    {
        public string DefaultTenant { get; set; } = default!;
        public List<Tenant> Tenants { get; set; } = default!;
    }
}
