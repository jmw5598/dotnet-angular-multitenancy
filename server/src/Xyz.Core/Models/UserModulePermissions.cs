using Xyz.Core.Entities.Tenant;

namespace Xyz.Core.Models
{
    public class UserModulePermissions
    {
        public ICollection<UserModulePermission> Modules { get; set; } = default!;
    }
}
