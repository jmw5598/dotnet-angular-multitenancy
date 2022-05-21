namespace Xyz.Core.Entities.Tenant
{
    public class TemplateModulePermission : BaseTemplateModulePermission
    {
        public Guid TemplateModulePermissionNameId { get; set; } = default!;
        public virtual ICollection<TemplatePermission> TemplatePermissions { get; set; } = default!;
    }
}