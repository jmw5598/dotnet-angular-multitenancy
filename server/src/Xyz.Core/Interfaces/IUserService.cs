namespace Xyz.Core.Interfaces
{
    public interface IUserService
    {
        Task<object> GetUserSettings(string userId);
        Task<object> GetUserPermissions(string userId);
    }
}
