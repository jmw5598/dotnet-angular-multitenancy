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
                this._logger.LogError(errorMessage, new { Exception = ex });
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
                    .Where(e => e.AspNetUserId.ToString() == userId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting user permissions!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                throw;
            }
        }

        public async Task<ICollection<UserPermission>> SaveUserPermissions(string  userId, ICollection<UserPermission> userPermissions)
        {
            try
            {
                var userPermissionsMapped = userPermissions.Select(p => {
                    return new UserPermission
                    {
                        Id = Guid.NewGuid(),
                        AspNetUserId = new Guid(userId),
                        PermissionId = p.Permission.Id,
                        CanCreate = p.CanCreate,
                        CanRead = p.CanCreate,
                        CanUpdate = p.CanDelete,
                        CanDelete = p.CanDelete,
                        ParentUserPermissionId = p.ParentUserPermissionId
                    };
                }).ToList();

                this._context.UserPermissions.AddRange(userPermissions);
                this._context.SaveChanges();

                return userPermissionsMapped;
            }
            catch (Exception ex)
            {
                var errorMessage = "Error saving user permissions!";
                this._logger.LogError(ex.ToString());
                this._logger.LogError(errorMessage, new { Exception = ex });
                throw;
            }
        }
    }
}