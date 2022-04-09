using Xyz.Core.Entities.Multitenancy;

namespace Xyz.Core.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public ICollection<ApplicationRole> Roles { get; set; } = default!;
    }
}