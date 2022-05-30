using Microsoft.AspNetCore.Identity;

namespace Xyz.Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid ProfileId { get; set; } = default!;
        public Profile Profile { get; set; } = default!;
        public ICollection<ApplicationUserRole> UserRoles { get; set; } = default!;
    }
}
