using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Xyz.Core.Entities.Tenant
{
    [Index(nameof(AspNetUserId))]
    public class UserPermission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool CanCreate { get; set; }
        public bool CanRead { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public Guid AspNetUserId { get; set; }
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; } = default!;
        public Guid UserModulePermissionId { get; set; }
        public UserModulePermission UserModulePermission { get; set; } = default!;
    }
}