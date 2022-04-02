using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using Xyz.Infrastructure.Data;
using Xyz.Core.Interfaces;
using Xyz.Core.Entities.Tenant;
using Xyz.Core.Models;

namespace Xyz.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UsersService> _logger;
        private readonly ApplicationDbContext _context;

        public UserService(ILogger<UsersService> logger, ApplicationDbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<UserSettings> GetUserSettings(string userId)
        {
            try
            {
                return await Task.FromResult(new UserSettings { });
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting user settings!";
                this._logger.LogError(errorMessage);
                throw;
            }
        }

        public async Task<ICollection<UserPermission>> GetUserPermissions(string userId)
        {
            try
            {
                return await this._context.UserPermissions
                    .Include(p => p.Permission)
                    .Select(e => e)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting user permissions!";
                this._logger.LogError(errorMessage);
                throw;
            }
        }
    }
}