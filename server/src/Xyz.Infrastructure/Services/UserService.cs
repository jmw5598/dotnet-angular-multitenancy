using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using Xyz.Infrastructure.Data;

using Xyz.Core.Interfaces;
using Xyz.Core.Entities.Tenant;
using Xyz.Core.Entities.Identity;
using Xyz.Core.Models;
using Xyz.Core.Dtos;

namespace Xyz.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UsersService> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public UserService(
            ILogger<UsersService> logger, 
            ApplicationDbContext applicationDbContext
        )
        {
            this._logger = logger;
            this._applicationDbContext = applicationDbContext;
        }

        public async Task<UserSettings> GetUserSettings(string userId)
        {
            try
            {
                var user = await this._applicationDbContext.Users
                    .Include(user => user.Profile)
                    .Where(u => u.Id.ToString() == userId)
                    .FirstOrDefaultAsync();

                return await Task.FromResult(new UserSettings {
                    UserDetails = new UserAccountDto
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        Profile = new Profile
                        {
                            Id = user.Profile.Id,
                            FirstName = user.Profile.FirstName,
                            LastName = user.Profile.LastName,
                            AvatarUrl = "https://i.pravatar.cc/300",
                        }
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

        public async Task<ICollection<UserModulePermissionDto>> GetUserModulePermissions(string userId)
        {
            try
            {
                // @TODO will have to rework the ordering here...
                var modulePermissions = this._applicationDbContext.UserModulePermissions
                    .Include(mp => mp.UserPermissions)
                    .ThenInclude(up =>  up.Permission)
                    .Include(mp => mp.ModulePermission)
                    .Where(ump => ump.AspNetUserId.ToString() == userId)
                    .OrderBy(um => um.ModulePermission.Name)
                    .Select(e => e.ToDto())
                    .ToListAsync();

                modulePermissions.Result.Select(mp => {
                    mp.UserPermissions = mp.UserPermissions.OrderBy(up => up?.Permission?.Name).ToList();
                    return mp;
                });

                return await modulePermissions;
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting user permissions!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                throw;
            }
        }

        public async Task<ICollection<UserModulePermissionDto>> SaveUserModulePermissions(string  userId, ICollection<UserModulePermission> userModulePermissions)
        {
            try
            {
                await this._applicationDbContext.UserModulePermissions.AddRangeAsync(userModulePermissions);                
                this._applicationDbContext.SaveChanges();
                return userModulePermissions.Select(ump => ump.ToDto()).ToList();
            }
            catch (Exception ex)
            {
                var errorMessage = "Error saving user permissions!";
                this._logger.LogError(ex.ToString());
                this._logger.LogError(errorMessage, new { Exception = ex });
                throw;
            }
        }

        public async Task<ICollection<UserModulePermissionDto>> UpdateUserModulePermissions(string  userId, ICollection<UserModulePermission> userModulePermissions)
        {
            try
            {
                var modulePermissions = this._applicationDbContext.UserModulePermissions
                    .Include(mp => mp.UserPermissions)
                    .Select(e => e)
                    .Where(ump => ump.AspNetUserId.ToString() == userId);

                this._applicationDbContext.UserModulePermissions.RemoveRange(modulePermissions);
                await this._applicationDbContext.UserModulePermissions.AddRangeAsync(userModulePermissions);

                this._applicationDbContext.SaveChanges();

                return userModulePermissions.Select(ump => ump.ToDto()).ToList();
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