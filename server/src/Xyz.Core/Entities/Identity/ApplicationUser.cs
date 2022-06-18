using Microsoft.AspNetCore.Identity;

using Xyz.Core.Entities.Tenants;

namespace Xyz.Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid ProfileId { get; set; } = default!;
        public Profile Profile { get; set; } = default!;
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = default!;
        public virtual ICollection<UserModulePermission> UserModulePermissions { get; set; } = default!;
    }
}
