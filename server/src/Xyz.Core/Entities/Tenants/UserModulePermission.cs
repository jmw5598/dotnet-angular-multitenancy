using Xyz.Core.Entities.Identity;
using Xyz.Core.Dtos;

namespace Xyz.Core.Entities.Tenants
{
    public class UserModulePermission : BaseTemplateModulePermission
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public virtual ApplicationUser User { get; set; } = default!;

        public virtual ICollection<UserPermission> UserPermissions { get; set; } = default!;
        public UserModulePermissionDto ToDto()
        {
            return new UserModulePermissionDto
            {
                Id = this.Id,
                HasAccess = this.HasAccess,
                ModulePermissionId = this.ModulePermissionId,
                ModulePermission = this.ModulePermission?.ToDto(),
                UserPermissions = this.UserPermissions.Select(e => e.ToDto()).ToList()
            };
        }
    }
}
