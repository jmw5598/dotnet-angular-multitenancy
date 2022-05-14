using Xyz.Core.Entities.Tenant;

namespace Xyz.Core.Interfaces
{
    public interface IPermissionsService
    {
        Task<IEnumerable<Permission>> FindAll();
        Task<IEnumerable<ModulePermission>> FindAllModulePermissions();
    }
}
