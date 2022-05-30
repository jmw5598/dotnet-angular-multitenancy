namespace Xyz.Core.Dtos
{
    public class TemplateModulePermissionNameDto
    {
        public Guid Id { get; set; } = Guid.NewGuid()!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow!;
        public UserDto CreatedBy { get; set; } = default!;
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow!;
        public UserDto UpdatedBy { get; set; } = default!;
        public ICollection<TemplateModulePermissionDto>? TemplateModulePermissions { get; set; } = default!;
    }
}
