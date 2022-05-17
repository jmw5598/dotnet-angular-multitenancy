using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Tenant;

namespace Xyz.Core.Dtos
{
    public class UserModulePermissionDto
    {
        public Guid Id { get; set; } = Guid.NewGuid()!;
        public bool HasAccess { get; set; } = default!;
        public Guid ModulePermissionId { get; set; } = default!;
        public ICollection<UserPermissionDto> UserPermissions { get; set; } = default!;
    }
}
