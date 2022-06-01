using Xyz.Core.Models;
using Xyz.Core.Dtos;
using Xyz.Core.Entities.Tenant;

namespace Xyz.Core.Interfaces
{
    public interface IUsersService
    {
        Task<UserSettings> GetUserSettings(string userId);
        Task<ICollection<UserModulePermissionDto>> GetUserModulePermissions(string userId);
        Task<ICollection<UserModulePermissionDto>> SaveUserModulePermissions(string  userId, ICollection<UserModulePermission> userModulePermissions);
        Task<ICollection<UserModulePermissionDto>> UpdateUserModulePermissions(string  userId, ICollection<UserModulePermission> userModulePermissions);
        Task<ValidationResult> VerifyEmail(string email);
        Task<ValidationResult> VerifyUserName(string userName);
        Task<Page<UserAccountDto>> SearchUsers(BasicQuerySearchFilter filter, PageRequest pageRequest);
        Task<UserAccountDto> CreateUserAccount(UserAccount userAccount);
        Task<UserAccountDto> UpdateUserAccount(string userId, UserAccount userAccount);
        Task<UserAccountDto> GetUserAccountByUserId(string userId);
    }
}
