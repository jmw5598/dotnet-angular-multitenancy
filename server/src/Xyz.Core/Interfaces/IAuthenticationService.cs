using Xyz.Core.Models;

namespace Xyz.Core.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<AuthenticatedUser> Login(Credentials crendentials);
        public Task<object> Register();
        public Task<object> ForgotPassword();
        public Task<object> ChangePassword();
    }
}