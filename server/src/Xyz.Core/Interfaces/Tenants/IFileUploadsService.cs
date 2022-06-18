using System.Security.Claims;

namespace Xyz.Core.Interfaces.Tenants
{
    public interface IFilesService
    {
        public Task<object> UploadAvatarAsync(object file);
    }
}
