using System.ComponentModel.DataAnnotations;

using Xyz.Core.Dtos;
using Xyz.Core.Entities.Tenants;

namespace Xyz.Api.Models
{
    public class CreateTemplateModulePermissionNameDto
    {
        [Required]
        public TemplateModulePermissionNameDto TemplateModulePermissionName { get; set; } = default!;

        [Required]
        public ICollection<TemplateModulePermissionDto> TemplateModulePermissions { get; set; } = default!;

        public TemplateModulePermissionName ToTemplateModulePermissionName()
        {
            return new TemplateModulePermissionName
            {
                Id = this.TemplateModulePermissionName.Id,
                CreatedOn = this.TemplateModulePermissionName.CreatedOn,
                UpdatedOn = this.TemplateModulePermissionName.UpdatedOn,
                DeleteOn = null,
                Name = this.TemplateModulePermissionName.Name,
                Description = this.TemplateModulePermissionName.Description,
                TemplateModulePermissions = TemplateModulePermissions
                    .Select(tmp => {
                        return new TemplateModulePermission
                        {
                            Id = tmp.Id,
                            HasAccess = tmp.HasAccess,
                            ModulePermissionId = tmp?.ModulePermission?.Id ?? Guid.NewGuid(),
                            TemplatePermissions = tmp?.TemplatePermissions
                                .Select(tp => {
                                    return new TemplatePermission
                                    {
                                        Id = tp.Id,
                                        CanCreate = tp.CanCreate,
                                        CanRead = tp.CanRead,
                                        CanUpdate = tp.CanUpdate,
                                        CanDelete = tp.CanDelete,
                                        PermissionId = tp?.Permission?.Id ?? Guid.NewGuid()
                                    };
                                })
                                .ToList() ?? new List<TemplatePermission> {}
                        };
                    })
                    .ToList()
            };
        }
    }
}
