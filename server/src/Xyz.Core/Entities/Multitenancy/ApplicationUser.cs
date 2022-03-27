using Microsoft.AspNetCore.Identity;

namespace Xyz.Core.Entities.Multitenancy
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid ProfileId { get; set; } = default!;
        public Profile Profile { get; set; } = default!;
        public ICollection<Tenant> Tenants { get; set; } = default!;
    }
}
