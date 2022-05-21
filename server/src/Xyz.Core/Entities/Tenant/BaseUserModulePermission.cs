namespace Xyz.Core.Entities.Tenant
{
    public abstract class BaseUserModulePermission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool HasAccess { get; set; } = default!;
        public Guid ModulePermissionId { get; set; }
        public virtual ModulePermission ModulePermission { get; set; } = default!;
        
    }
}
