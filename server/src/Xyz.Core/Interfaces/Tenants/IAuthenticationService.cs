using Xyz.Core.Models.Tenants;

namespace Xyz.Core.Interfaces.Tenants
{
    public interface IAuthenticationService
    {
        public Task<AuthenticatedUser> LoginAsync(Credentials crendentials);
        public Task<object> ForgotPasswordAsync();
        public Task<object> ChangePasswordAsync();
        public Task<AuthenticatedUser> RefreshAccessTokenAsync(RefreshTokenRequest refreshTokenRequest);
    }
}