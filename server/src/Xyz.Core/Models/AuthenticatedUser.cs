namespace Xyz.Core.Models
{
    public class AuthenticatedUser
    {
        public string Status { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}