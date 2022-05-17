using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Tenant;

namespace Xyz.Core.Dtos
{
    public class PermissionDto
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
