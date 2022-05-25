using Xyz.Core.Dtos;

namespace Xyz.Core.Entities.Tenant
{
    public class TemplateModulePermission : BaseTemplateModulePermission
    {
        public Guid TemplateModulePermissionNameId { get; set; } = default!;
        public virtual TemplateModulePermissionName TemplateModulePermissionName { get; set; } = default!;
        public virtual ICollection<TemplatePermission> TemplatePermissions { get; set; } = default!;
    
        public TemplateModulePermissionDto ToDto()
        {
            return new TemplateModulePermissionDto
            {
                Id = this.Id,
                HasAccess = this.HasAccess,
                ModulePermissionId = this.ModulePermissionId,
                ModulePermission = this.ModulePermission?.ToDto(),
                TemplatePermissions = this.TemplatePermissions.Select(e => e.ToDto()).ToList()
            };
        }
    }
}
