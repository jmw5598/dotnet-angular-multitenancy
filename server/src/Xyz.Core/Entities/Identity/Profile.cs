namespace Xyz.Core.Entities.Identity
{
    public class Profile
    {
        public Guid Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? AvatarUrl { get; set; } = default!;
    }
}
