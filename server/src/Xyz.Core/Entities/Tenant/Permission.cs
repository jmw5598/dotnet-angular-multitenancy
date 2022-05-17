namespace Xyz.Core.Entities.Tenant
{
    public class Permission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public Guid ModulePermissionId { get; set; }
        public virtual ModulePermission ModulePermission { get; set; } = default!;
    }
}
