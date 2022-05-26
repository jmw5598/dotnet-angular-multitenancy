namespace Xyz.Core.Dtos
{
    public class TemplateModulePermissionNameDto
    {
        public Guid Id { get; set; } = Guid.NewGuid()!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime CreatedOn { get; set; } = DateTime.Now!;
        public DateTime UpdatedOn { get; set; } = DateTime.Now!;
    }
}
