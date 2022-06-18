using Xyz.Core.Dtos;

namespace Xyz.Core.Entities.Tenants
{
    public class TemplatePermission : BaseTemplatePermission
    {
        public Guid TemplateModulePermissionId { get; set; }

        public TemplatePermissionDto ToDto()
        {
            return new TemplatePermissionDto
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