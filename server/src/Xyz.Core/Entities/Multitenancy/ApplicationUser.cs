using Microsoft.AspNetCore.Identity;

namespace Xyz.Core.Entities.Multitenancy
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ICollection<Tenant> Tenants { get; set; } = default!;
    }
}
