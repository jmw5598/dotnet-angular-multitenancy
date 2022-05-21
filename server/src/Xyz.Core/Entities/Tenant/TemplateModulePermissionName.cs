namespace Xyz.Core.Entities.Tenant
{
    public class TemplateModulePermissionName
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public virtual ICollection<TemplateModulePermission> TemplateModulePermissions { get; set; } = default!;
    }
}
