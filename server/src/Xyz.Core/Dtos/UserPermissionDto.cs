using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Tenant;

namespace Xyz.Core.Dtos
{
    public class UserPermissionDto
    {
        public Guid Id { get; set; } = Guid.NewGuid()!;
        public bool CanCreate { get; set; } = default!;
        public bool CanRead { get; set; } = default!;
        public bool CanUpdate { get; set; } = default!;
        public bool CanDelete { get; set; } = default!;
        public Guid PermissionId { get; set; } = default!;
    }
}