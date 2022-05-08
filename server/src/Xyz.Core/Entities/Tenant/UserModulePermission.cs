namespace Xyz.Core.Entities.Tenant
{
    public class UserModulePermission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool HasAccess { get; set; } = default!;
        public Guid ModulePermissionId { get; set; }
        public virtual ModulePermission ModulePermission { get; set; } = default!;
        public virtual ICollection<UserPermission> UserPermissions { get; set; } = default!;
    }
}
