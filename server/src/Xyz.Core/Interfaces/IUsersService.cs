using Xyz.Core.Models;
using Xyz.Core.Dtos;

namespace Xyz.Core.Interfaces
{
    public interface IUsersService
    {
        Task<ValidationResult> VerifyEmail(string email);
        Task<ValidationResult> VerifyUserName(string userName);
        Task<Page<UserDto>> SearchUsersByTenant(string tenantId, PageRequest pageRequest);
        Task<UserDto> CreateUserAccount(string tenantId, UserAccount userAccount);
    }
}
