using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using System.Data;


using Xyz.Core.Interfaces.Tenants;
using Xyz.Core.Entities.Tenants;
using Xyz.Infrastructure.Data;

namespace Xyz.Infrastructure.Services.Tenants
{
    public class FilesService : IFilesService
    {
        private readonly ILogger<FilesService> _logger;
        private readonly ApplicationDbContext _context;

        public FilesService(ILogger<FilesService> logger, ApplicationDbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<object> UploadAvatarAsync(object file)
        {
            throw new NotImplementedException();
        }
    }
}
