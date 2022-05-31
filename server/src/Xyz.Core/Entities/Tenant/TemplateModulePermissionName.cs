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
                CreatedBy = this.CreatedBy != null ? 
                    new UserDto
                    {
                        Id = this.CreatedBy.Id,
                        UserName = this.CreatedBy.UserName
                    }
                    : null,
                UpdatedOn = this.UpdatedOn,
                UpdatedBy = this.UpdatedBy != null 
                    ? new UserDto
                    {
                        Id = this.UpdatedBy.Id,
                        UserName = this.UpdatedBy.UserName
                    } 
                    : null,
                TemplateModulePermissions = this.TemplateModulePermissions
                    ?.Select(tmp => tmp.ToDto())
                    ?.ToList() ?? new List<TemplateModulePermissionDto> {}
            };
        }
    }
}
