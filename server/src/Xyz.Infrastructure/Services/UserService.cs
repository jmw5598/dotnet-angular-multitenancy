using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using Xyz.Infrastructure.Data;
using Xyz.Multitenancy.Data;
using Xyz.Core.Interfaces;
using Xyz.Core.Entities.Tenant;
using Xyz.Core.Models;
using Xyz.Core.Dtos;

namespace Xyz.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UsersService> _logger;
        private readonly ApplicationDbContext _context;
        private readonly AuthenticationDbContext _authContext;

        public UserService(
            ILogger<UsersService> logger, 
            ApplicationDbContext context,
            AuthenticationDbContext authContext
        )
        {
            this._logger = logger;
            this._context = context;
            this._authContext = authContext;
        }

        public async Task<UserSettings> GetUserSettings(string userId)
        {
            try
            {
                var user = await this._authContext.Users
                    .Include(user => user.Profile)
                    .Where(u => u.Id.ToString() == userId)
                    .FirstOrDefaultAsync();

                return await Task.FromResult(new UserSettings {
                    UserDetails = new UserAccountDto
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        FirstName = user.Profile.FirstName,
                        LastName = user.Profile.LastName,
                        AvatarSrc = "https://i.pravatar.cc/300",
                    }
                });
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
                var listOfUserPermissions = new List<UserPermission>();

                foreach (var userPermission in userPermissions)
                {
                    
                }
                
                this._context.SaveChanges();
                return listOfUserPermissions;
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