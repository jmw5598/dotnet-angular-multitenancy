namespace Xyz.Core.Entities.Tenant
{
    public abstract class BaseUserPermission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool CanCreate { get; set; }
        public bool CanRead { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public Guid PermissionId { get; set; }
        public virtual Permission Permission { get; set; } = default!;
    }
}
