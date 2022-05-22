using Xyz.Core.Models;
using Xyz.Core.Dtos;

namespace Xyz.Core.Interfaces
{
    public interface IUsersService
    {
        Task<ValidationResult> VerifyEmail(string email);
        Task<ValidationResult> VerifyUserName(string userName);
        Task<Page<UserAccountDto>> SearchUsersByTenant(string tenantId, BasicQuerySearchFilter filter, PageRequest pageRequest);
        Task<UserAccountDto> CreateUserAccount(string tenantId, UserAccount userAccount);
        Task<UserAccountDto> UpdateUserAccount(string tenantId, string userId, UserAccount userAccount);
        Task<UserAccountDto> GetUserAccountByUserId(string userId);
    }
}
