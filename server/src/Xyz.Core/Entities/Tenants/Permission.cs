using Xyz.Core.Dtos;

namespace Xyz.Core.Entities.Tenants
{
    public class Permission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public Guid ModulePermissionId { get; set; }

        public PermissionDto ToDto()
        {
            return new PermissionDto
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}
