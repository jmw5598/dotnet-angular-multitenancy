using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using System.Data;


using Xyz.Core.Interfaces;
using Xyz.Core.Entities.Tenant;
using Xyz.Infrastructure.Data;

namespace Xyz.Infrastructure.Services
{
    public class FilesService : IFilesService
    {
        private readonly ILogger<PlansService> _logger;
        private readonly ApplicationDbContext _context;

        public FilesService(ILogger<PlansService> logger, ApplicationDbContext context)
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
