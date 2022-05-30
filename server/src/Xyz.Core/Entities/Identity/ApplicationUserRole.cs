using Microsoft.AspNetCore.Identity;

namespace Xyz.Core.Entities.Identity
{
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public override Guid UserId { get; set; } = default!;
        public virtual ApplicationUser User { get; set; } = default!;
        public override Guid RoleId { get; set; } = default!;
        public virtual ApplicationRole Role { get; set; } = default!;
    }
}