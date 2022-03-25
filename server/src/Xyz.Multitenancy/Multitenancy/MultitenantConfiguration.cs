using Xyz.Core.Entities.Multitenancy;

namespace Xyz.Multitenancy.Multitenancy
{
    public class MultitenantConfiguration
    {
        public string DefaultTenant { get; set; }
        public List<Tenant> Tenants { get; set; }
    }
}
