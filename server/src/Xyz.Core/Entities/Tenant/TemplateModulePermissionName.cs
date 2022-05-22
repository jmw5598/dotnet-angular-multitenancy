using Xyz.Core.Dtos;

namespace Xyz.Core.Entities.Tenant
{
    public class TemplateModulePermissionName : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public virtual ICollection<TemplateModulePermission> TemplateModulePermissions { get; set; } = default!;

        public TemplateModulePermissionNameDto ToDto()
        {
            return new TemplateModulePermissionNameDto
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                CreatedOn = this.CreatedOn,
                UpdatedOn = this.UpdatedOn,
                // @TODO map permissions
            };
        }
    }
}
