using Microsoft.EntityFrameworkCore;
using Xyz.Core.Dtos;

namespace Xyz.Core.Entities.Tenant
{
    [Index(nameof(AspNetUserId))]
    public class UserModulePermission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool HasAccess { get; set; } = default!;
        public Guid AspNetUserId { get; set; }
        public Guid ModulePermissionId { get; set; }
        public virtual ModulePermission ModulePermission { get; set; } = default!;
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
