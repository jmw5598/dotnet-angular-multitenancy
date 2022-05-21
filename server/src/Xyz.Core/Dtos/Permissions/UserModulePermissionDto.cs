namespace Xyz.Core.Dtos
{
    public class UserModulePermissionDto
    {
        public Guid Id { get; set; } = Guid.NewGuid()!;
        public bool HasAccess { get; set; } = default!;
        public Guid ModulePermissionId { get; set; } = default!;
        public ModulePermissionDto? ModulePermission { get; set; } = default!;
        public ICollection<UserPermissionDto> UserPermissions { get; set; } = default!;
    }
}
