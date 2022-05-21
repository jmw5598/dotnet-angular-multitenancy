using Xyz.Core.Dtos;

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

        public UserPermissionDto ToDto()
        {
            return new UserPermissionDto
            {
                Id = this.Id,
                CanCreate = this.CanCreate,
                CanRead = this.CanRead,
                CanUpdate = this.CanUpdate,
                CanDelete = this.CanDelete,
                PermissionId = this.PermissionId,
                Permission = this.Permission?.ToDto() ?? null
            };
        }
    }
}