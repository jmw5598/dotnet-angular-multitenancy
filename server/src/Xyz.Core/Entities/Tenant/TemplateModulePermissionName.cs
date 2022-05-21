namespace Xyz.Core.Entities.Tenant
{
    public class TemplateModulePermissionName : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public virtual ICollection<TemplateModulePermission> TemplateModulePermissions { get; set; } = default!;
    }
}
