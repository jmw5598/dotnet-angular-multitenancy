using System.Security.Claims;

namespace Xyz.Core.Interfaces
{
    public interface IFilesService
    {
        public Task<object> UploadAvatarAsync(object file);
    }
}
