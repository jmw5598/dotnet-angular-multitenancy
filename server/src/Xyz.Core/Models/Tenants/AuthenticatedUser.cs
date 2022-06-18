namespace Xyz.Core.Models.Tenants
{
    public class AuthenticatedUser
    {
        public string Status { get; set; } = default!;
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;

    }
}