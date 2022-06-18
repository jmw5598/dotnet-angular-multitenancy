using Xyz.Core.Entities.Identity;
using Xyz.Core.Entities.Tenants;

namespace Xyz.Core.Models.Tenants
{
    public class UserAccount
    {
        public ApplicationUser User { get; set; } = default!;
        public ICollection<ApplicationRole> Roles { get; set; } = default!;
        public ICollection<UserModulePermission> UserModulePermissions { get; set; } = default!;
        public string RawPassword { get; set; } = default!;
    }
}