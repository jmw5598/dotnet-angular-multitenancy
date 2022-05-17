namespace Xyz.Core.Entities.Tenant
{
    public class UserPermission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool CanCreate { get; set; }
        public bool CanRead { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public Guid PermissionId { get; set; }
        public virtual Permission Permission { get; set; } = default!;
        public Guid UserModulePermissionId { get; set; }
        public virtual UserModulePermission UserModulePermission { get; set; } = default!;
    }
}