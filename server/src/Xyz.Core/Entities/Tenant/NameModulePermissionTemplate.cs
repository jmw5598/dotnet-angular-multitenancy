namespace Xyz.Core.Entities.Tenant
{
    public class NamedModulePermissionTemplate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public virtual ICollection<UserModulePermissionTemplate> UserModulePermissionTemplates { get; set; } = default!;
    }
}
