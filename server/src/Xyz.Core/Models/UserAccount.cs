using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Tenant;

namespace Xyz.Core.Models
{
    public class UserAccount
    {
        public ApplicationUser User { get; set; } = default!;
        public ICollection<UserPermission> UserPermissions { get; set; } = default!;
        public string RawPassword { get; set; } = default!;
    }
}