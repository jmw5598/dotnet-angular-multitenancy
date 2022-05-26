namespace Xyz.Core.Dtos
{
    public class TemplateModulePermissionDto
    {
        public Guid Id { get; set; } = Guid.NewGuid()!;
        public bool HasAccess { get; set; } = default!;
        public Guid ModulePermissionId { get; set; } = default!;
        public ModulePermissionDto? ModulePermission { get; set; } = default!;
        public ICollection<TemplatePermissionDto> TemplatePermissions { get; set; } = default!;
    }
}
