using Xyz.Core.Dtos;

namespace Xyz.Core.Entities.Tenant
{
    public class UserPermission : BaseUserPermission
    {
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