namespace Xyz.Core.Entities.Tenants
{
    public abstract class BaseTemplateModulePermission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool HasAccess { get; set; } = default!;
        public Guid ModulePermissionId { get; set; }
        public virtual ModulePermission ModulePermission { get; set; } = default!;
        
    }
}
