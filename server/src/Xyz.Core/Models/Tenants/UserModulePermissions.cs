using Xyz.Core.Dtos;

namespace Xyz.Core.Models.Tenants
{
    public class UserModulePermissions
    {
        public ICollection<UserModulePermissionDto> Modules { get; set; } = default!;
    }
}
