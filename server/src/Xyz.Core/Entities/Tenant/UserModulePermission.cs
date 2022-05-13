using Microsoft.EntityFrameworkCore;

namespace Xyz.Core.Entities.Tenant
{
    [Index(nameof(AspNetUserId))]
    public class UserModulePermission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool HasAccess { get; set; } = default!;
        public Guid AspNetUserId { get; set; }
        public Guid ModulePermissionId { get; set; }
        public virtual ModulePermission ModulePermission { get; set; } = default!;
        public virtual ICollection<UserPermission> UserPermissions { get; set; } = default!;
    }
}
