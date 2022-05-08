namespace Xyz.Core.Entities.Tenant
{
    public class ModulePermission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public virtual ICollection<Permission> Permissions { get; set; } = default!;
    }
}
