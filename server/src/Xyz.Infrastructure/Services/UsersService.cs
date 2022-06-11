using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using System.Data;

using Xyz.Infrastructure.Data;
using Xyz.Core.Interfaces;
using Xyz.Core.Models;
using Xyz.Core.Dtos;
using Xyz.Core.Entities.Identity;
using Xyz.Core.Entities.Tenant;

namespace Xyz.Infrastructure.Services
{
    public class UsersService : IUsersService
    {
        private readonly ILogger<UsersService> _logger;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UsersService(
            ILogger<UsersService> logger, 
            ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this._logger = logger;
            this._applicationDbContext = applicationDbContext;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task<UserSettings> GetUserSettingsAsync(string userId)
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

        public async Task<ICollection<UserModulePermissionDto>> GetUserModulePermissionsAsync(string userId)
        {
            try
            {
                // @TODO will have to rework the ordering here...
                var modulePermissions = this._applicationDbContext.UserModulePermissions
                    .Include(mp => mp.UserPermissions)
                    .ThenInclude(up =>  up.Permission)
                    .Include(mp => mp.ModulePermission)
                    .Where(ump => ump.UserId.ToString() == userId)
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

        public async Task<ICollection<UserModulePermissionDto>> SaveUserModulePermissionsAsync(string  userId, ICollection<UserModulePermission> userModulePermissions)
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

        public async Task<ICollection<UserModulePermissionDto>> UpdateUserModulePermissionsAsync(string  userId, ICollection<UserModulePermission> userModulePermissions)
        {
            try
            {
                var modulePermissions = this._applicationDbContext.UserModulePermissions
                    .Include(mp => mp.UserPermissions)
                    .Select(e => e)
                    .Where(ump => ump.UserId.ToString() == userId);

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

        public async Task<ValidationResult> VerifyEmailAsync(string email)
        {
            var foundEmail = this._applicationDbContext.Users
                .FirstOrDefault(user => user.Email.ToLower() == email.ToLower());
            
            return await Task.FromResult(
                new ValidationResult
                {
                    IsValid = foundEmail == null
                }
            );
        }

        public async Task<ValidationResult> VerifyUserNameAsync(string userName)
        {
            var foundUserName = this._applicationDbContext.Users
                .FirstOrDefault(user => user.UserName.ToLower() == userName.ToLower());

            return await Task.FromResult(
                new ValidationResult
                {
                    IsValid = foundUserName == null
                }
            );
        }

        public async Task<Page<UserAccountDto>> SearchUsersAsync(BasicQuerySearchFilter filter, PageRequest pageRequest)
        {
            IQueryable<ApplicationUser> query = this._applicationDbContext.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Include(u => u.Profile)
                .Where(user => !user.UserRoles.Any(ur => ur.Role.Name == Roles.ADMIN));

            if (filter?.Query != null)
            {
                var queryTerm = filter.Query.Trim().ToLower();
                query = query.Where(user => 
                    user.UserName.ToLower().Contains(queryTerm)
                        || user.Email.ToLower().Contains(queryTerm)
                        || user.Profile.FirstName.ToLower().Contains(queryTerm)
                        || user.Profile.LastName.ToLower().Contains(queryTerm));
            }

            if (pageRequest.Sort != null)
            {
                switch (pageRequest.Sort.Column)
                {
                    case "userName":
                        query = pageRequest.Sort.Direction == SortDirection.Ascend
                            ? query.OrderBy(u => u.UserName)
                            : query.OrderByDescending(u => u.UserName);
                        break;
                    case "email":
                        query = pageRequest.Sort.Direction == SortDirection.Ascend
                            ? query.OrderBy(u => u.Email)
                            : query.OrderByDescending(u => u.Email);
                        break;
                    case "profile.firstName":
                        query = pageRequest.Sort.Direction == SortDirection.Ascend
                            ? query.OrderBy(u => u.Profile.FirstName)
                            : query.OrderByDescending(u => u.Profile.FirstName);
                        break;
                    case "profile.lastName":
                        query = pageRequest.Sort.Direction == SortDirection.Ascend
                            ? query.OrderBy(u => u.Profile.LastName)
                            : query.OrderByDescending(u => u.Profile.LastName);
                        break;
                    case "id":
                    default:
                        query = pageRequest.Sort.Direction == SortDirection.Ascend 
                            ? query.OrderBy(t => t.Id)
                            : query.OrderByDescending(t => t.Id);
                        break;
                }
            }
                
            var usersSource = query
                .Select(u => new UserAccountDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    Profile = new Profile
                    {
                        FirstName = u.Profile.FirstName,
                        LastName = u.Profile.LastName,
                        AvatarUrl = "https://i.pravatar.cc/300",
                    },
                    Roles = u.UserRoles.Select(u => u.Role).ToList()
                });

            return await Page<UserAccountDto>.From(usersSource, pageRequest);
        }

        public async Task<UserAccountDto> CreateUserAccountAsync(UserAccount userAccount)
        {
            using var transaction = this._applicationDbContext.Database.BeginTransaction();

            try 
            {
                var userRole = await this._roleManager.FindByNameAsync(Roles.USER);
                var userIdentityResult = await this._userManager.CreateAsync(userAccount.User, userAccount.RawPassword);
                
                if (!userIdentityResult.Succeeded)
                {
                    throw new Exception("Error creating new user!");
                }

                var addRoleIdentityResult = await this._userManager.AddToRoleAsync(userAccount.User, Roles.USER);

                if (!addRoleIdentityResult.Succeeded)
                {
                    throw new Exception("Error adding role to new user");
                }

                transaction.Commit();

                return new UserAccountDto
                {
                    Id = userAccount.User.Id,
                    Email = userAccount.User.Email,
                    Profile = new Profile
                    {
                        FirstName = userAccount.User.Profile.FirstName,
                        LastName = userAccount.User.Profile.LastName,
                        AvatarUrl = "https://i.pravatar.cc/300",
                    },
                    Roles = userAccount.User.UserRoles.Select(u => u.Role).ToList()
                };
            }
            catch (Exception e)
            {
                transaction.Rollback();
                var errorMessage = "Error registering new user account!";
                this._logger.LogError(errorMessage, e);
                throw new Exception(errorMessage);
            }
        }

        public async Task<UserAccountDto> UpdateUserAccountAsync(string userId, UserAccount userAccount)
        {
            try 
            {
                var user = await this._applicationDbContext.Users
                    .Include(u => u.Profile)
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .Where(u => u.Id.ToString() == userId)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new Exception("User with the supplied ID was not found!");
                }

                user.Profile.FirstName = userAccount.User.Profile.FirstName;
                user.Profile.LastName = userAccount.User.Profile.LastName;
                user.Profile.AvatarUrl = userAccount.User.Profile.AvatarUrl;

                this._applicationDbContext.Users.Update(user);
                this._applicationDbContext.SaveChanges();

                return new UserAccountDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Profile = new Profile
                    {
                        FirstName = user.Profile.FirstName,
                        LastName = user.Profile.LastName,
                        AvatarUrl = "https://i.pravatar.cc/300",
                    },
                    Roles = user.UserRoles.Select(u => u.Role).ToList()
                };
            }
            catch (Exception e)
            {
                var errorMessage = "Error updating user account!";
                this._logger.LogError(errorMessage, e);
                throw new Exception(errorMessage);
            }
        }

        public async Task<UserAccountDto> GetUserAccountByUserIdAsync(string userId)
        {
            try
            {
                var user = await this._applicationDbContext.Users
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .Include(u => u.Profile)
                    .Where(u => u.Id.ToString() == userId)
                    .Select(u => new UserAccountDto
                    {
                        Id = u.Id,
                        UserName = u.UserName,
                        Email = u.Email,
                        Profile = new Profile
                        {
                            FirstName = u.Profile.FirstName,
                            LastName = u.Profile.LastName,
                            AvatarUrl = "https://i.pravatar.cc/300",
                        },
                        Roles = u.UserRoles.Select(ur => ur.Role).ToList()
                    })
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new Exception("User not found!");
                }

                return user;
            }
            catch (Exception e)
            {
                var errorMessage = "Error getting user account!";
                this._logger.LogError(errorMessage, e);
                throw new Exception(errorMessage);
            }
        }
    }
}
