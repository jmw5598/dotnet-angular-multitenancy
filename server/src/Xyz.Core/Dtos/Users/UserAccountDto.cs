using Xyz.Core.Entities.Identity;

namespace Xyz.Core.Dtos
{
    public class UserAccountDto
    {
        public Guid Id { get; set; } = default!;
        public string? UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Profile Profile { get; set; } = default!;
        public ICollection<ApplicationRole> Roles { get; set; } = default!;
        public ICollection<UserModulePermissionDto> UserModulePermissions { get; set; } = default!;
    }
}