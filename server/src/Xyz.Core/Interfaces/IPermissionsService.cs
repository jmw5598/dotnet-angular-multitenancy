using Xyz.Core.Entities.Tenant;

namespace Xyz.Core.Interfaces
{
    public interface IPermissionsService
    {
        Task<IEnumerable<Permission>> FindAll();
    }
}
