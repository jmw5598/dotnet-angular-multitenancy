namespace Xyz.Core.Dtos
{
    public class ModulePermissionDto
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public ICollection<PermissionDto>? Permissions { get; set; } = default!;
    }
}