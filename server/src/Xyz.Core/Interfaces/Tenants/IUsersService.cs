using Xyz.Core.Models;
using Xyz.Core.Models.Tenants;
using Xyz.Core.Models.Paging;
using Xyz.Core.Models.SearchFilters;
using Xyz.Core.Dtos;
using Xyz.Core.Entities.Tenants;

namespace Xyz.Core.Interfaces.Tenants
{
    public interface IUsersService
    {
        Task<UserSettings> GetUserSettingsAsync(string userId);
        Task<ICollection<UserModulePermissionDto>> GetUserModulePermissionsAsync(string userId);
        Task<ICollection<UserModulePermissionDto>> SaveUserModulePermissionsAsync(string  userId, ICollection<UserModulePermission> userModulePermissions);
        Task<ICollection<UserModulePermissionDto>> UpdateUserModulePermissionsAsync(string  userId, ICollection<UserModulePermission> userModulePermissions);
        Task<ValidationResult> VerifyEmailAsync(string email);
        Task<ValidationResult> VerifyUserNameAsync(string userName);
        Task<Page<UserAccountDto>> SearchUsersAsync(BasicQuerySearchFilter filter, PageRequest pageRequest);
        Task<UserAccountDto> CreateUserAccountAsync(UserAccount userAccount);
        Task<UserAccountDto> UpdateUserAccountAsync(string userId, UserAccount userAccount);
        Task<UserAccountDto> GetUserAccountByUserIdAsync(string userId);
    }
}
