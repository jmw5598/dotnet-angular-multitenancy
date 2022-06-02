namespace Xyz.Core.Entities.Identity
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Token { get; set; } = Guid.NewGuid();
        public bool IsBlacklisted { get; set; } = false;

        public Guid UserId { get; set; } = default!;
        public ApplicationUser User { get; set; } = default!;
    }
}
