using Xyz.Core.Dtos;

namespace Xyz.Core.Entities.Tenant
{
    public class ModulePermission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public virtual ICollection<Permission> Permissions { get; set; } = default!;

        public ModulePermissionDto ToDto()
        {
            return new ModulePermissionDto
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}
