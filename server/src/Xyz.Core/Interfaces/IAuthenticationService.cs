namespace Xyz.Core.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<object> Login();
        public Task<object> Register();
        public Task<object> ForgotPassword();
        public Task<object> ChangePassword();
    }
}