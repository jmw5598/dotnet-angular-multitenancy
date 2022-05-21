namespace Xyz.Core.Entities.Tenant
{
    public class UserModulePermissionTemplate : BaseUserModulePermission
    {
        public Guid TemplateId { get; set; } = default!;
        public virtual ICollection<UserPermissionTemplate> UserPermissionTemplates { get; set; } = default!;
    }
}