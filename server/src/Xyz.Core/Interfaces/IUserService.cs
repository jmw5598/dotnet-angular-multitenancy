using Xyz.Core.Models;
using Xyz.Core.Entities.Tenant;

namespace Xyz.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserSettings> GetUserSettings(string userId);
        Task<ICollection<UserModulePermission>> GetUserModulePermissions(string userId);
        Task<ICollection<UserPermission>> SaveUserPermissions(string  userId, ICollection<UserPermission> userPermissions);
    }
}
