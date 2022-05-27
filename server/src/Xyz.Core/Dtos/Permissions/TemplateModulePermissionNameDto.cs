namespace Xyz.Core.Dtos
{
    public class TemplateModulePermissionNameDto
    {
        public Guid Id { get; set; } = Guid.NewGuid()!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow!;
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow!;
        public ICollection<TemplateModulePermissionDto> TemplateModulePermissions { get; set; } = default!;
    }
}
