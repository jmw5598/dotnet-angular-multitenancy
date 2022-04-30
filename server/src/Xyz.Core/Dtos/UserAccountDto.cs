using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Tenant;

namespace Xyz.Core.Dtos
{
    public class UserAccountDto
    {
        public Guid Id { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string AvatarSrc { get; set; } = default!;
        public ICollection<ApplicationRole> Roles { get; set; } = default!;
        public ICollection<UserPermission> UserPermissions { get; set; } = default!;
    }
}