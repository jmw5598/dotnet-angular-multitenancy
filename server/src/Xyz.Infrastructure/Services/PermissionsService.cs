using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using System.Data;


using Xyz.Core.Interfaces;
using Xyz.Core.Entities.Tenant;
using Xyz.Infrastructure.Data;

namespace Xyz.Infrastructure.Services
{
    public class PermissionsService : IPermissionsService
    {
        private readonly ILogger<PlansService> _logger;
        private readonly ApplicationDbContext _context;

        public PermissionsService(ILogger<PlansService> logger, ApplicationDbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<IEnumerable<Permission>> FindAll()
        {
            return await this._context.Permissions
                .Select(p => p)
                .ToListAsync();
        }

        public async Task<IEnumerable<ModulePermission>> FindAllModulePermissions()
        {
            return await this._context.ModulePermissions
                .Include(m => m.Permissions)
                .Select(mp => mp)
                .ToListAsync();
        }
    }
}