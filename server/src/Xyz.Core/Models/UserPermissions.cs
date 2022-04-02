using Xyz.Core.Entities.Tenant;

namespace Xyz.Core.Models
{
    public class UserPermissions
    {
        public ICollection<UserPermission> Permissions { get; set; } = default!;
    }
}
