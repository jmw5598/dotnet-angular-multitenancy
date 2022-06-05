using Xyz.Core.Models;
using Xyz.Core.Dtos;

namespace Xyz.Core.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<AuthenticatedUser> Login(Credentials crendentials);
        public Task<object> Register(Registration registration);
        public Task<object> ForgotPassword();
        public Task<object> ChangePassword();
        public Task<AuthenticatedUser> RefreshAccessToken(RefreshTokenRequest refreshTokenRequest);
        public Task<Page<TenantDto>> SearchCompanies(BasicQuerySearchFilter filter, PageRequest pageRequest);
    }
}