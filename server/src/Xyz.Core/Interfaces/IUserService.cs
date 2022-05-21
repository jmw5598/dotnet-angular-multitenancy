using Xyz.Core.Models;
using Xyz.Core.Entities.Tenant;
using Xyz.Core.Dtos;

namespace Xyz.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserSettings> GetUserSettings(string userId);
        Task<ICollection<UserModulePermissionDto>> GetUserModulePermissions(string userId);
        Task<ICollection<UserModulePermissionDto>> SaveUserModulePermissions(string  userId, ICollection<UserModulePermission> userModulePermissions);
        Task<ICollection<UserModulePermissionDto>> UpdateUserModulePermissions(string  userId, ICollection<UserModulePermission> userModulePermissions);
    }
}
