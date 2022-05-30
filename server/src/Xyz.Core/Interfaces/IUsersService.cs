using Xyz.Core.Models;
using Xyz.Core.Dtos;

namespace Xyz.Core.Interfaces
{
    public interface IUsersService
    {
        Task<ValidationResult> VerifyEmail(string email);
        Task<ValidationResult> VerifyUserName(string userName);
        Task<Page<UserAccountDto>> SearchUsers(BasicQuerySearchFilter filter, PageRequest pageRequest);
        Task<UserAccountDto> CreateUserAccount(UserAccount userAccount);
        Task<UserAccountDto> UpdateUserAccount(string userId, UserAccount userAccount);
        Task<UserAccountDto> GetUserAccountByUserId(string userId);
    }
}
