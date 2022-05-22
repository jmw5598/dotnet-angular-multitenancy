namespace Xyz.Core.Dtos
{
    public class TemplateModulePermissionNameDto
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime CreatedOn { get; set; } = default!;
        public DateTime UpdatedOn { get; set; } = default!;
    }
}
