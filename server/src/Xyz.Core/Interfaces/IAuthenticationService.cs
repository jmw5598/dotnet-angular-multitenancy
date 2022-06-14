using Xyz.Core.Models;
using Xyz.Core.Models.Paging;
using Xyz.Core.Models.SearchFilters;
using Xyz.Core.Dtos;

namespace Xyz.Core.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<AuthenticatedUser> LoginAsync(Credentials crendentials);
        public Task<object> RegisterAsync(Registration registration);
        public Task<object> ForgotPasswordAsync();
        public Task<object> ChangePasswordAsync();
        public Task<AuthenticatedUser> RefreshAccessTokenAsync(RefreshTokenRequest refreshTokenRequest);
        public Task<Page<TenantDto>> SearchCompaniesAsync(BasicQuerySearchFilter filter, PageRequest pageRequest);
    }
}