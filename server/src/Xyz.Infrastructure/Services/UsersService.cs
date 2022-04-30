using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using System.Data;

using Xyz.Multitenancy.Data;
using Xyz.Core.Interfaces;
using Xyz.Core.Models;
using Xyz.Core.Dtos;
using Xyz.Core.Entities.Multitenancy;

namespace Xyz.Infrastructure.Services
{
    public class UsersService : IUsersService
    {
        private readonly ILogger<UsersService> _logger;
        private readonly AuthenticationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UsersService(
            ILogger<UsersService> logger, 
            AuthenticationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this._logger = logger;
            this._context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }


        public async Task<ValidationResult> VerifyEmail(string email)
        {
            var foundEmail = this._context.Users
                .FirstOrDefault(user => user.Email.ToLower() == email.ToLower());
            
            return await Task.FromResult(
                new ValidationResult
                {
                    IsValid = foundEmail == null
                }
            );
        }

        public async Task<ValidationResult> VerifyUserName(string userName)
        {
            var foundUserName = this._context.Users
                .FirstOrDefault(user => user.UserName.ToLower() == userName.ToLower());

            return await Task.FromResult(
                new ValidationResult
                {
                    IsValid = foundUserName == null
                }
            );
        }

        public async Task<Page<UserAccountDto>> SearchUsersByTenant(string tenantId, PageRequest pageRequest)
        {
            var usersSource = this._context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Include(u => u.Tenants)
                .Include(u => u.Profile)
                .Where(u => 
                    u.Tenants
                        .Where(t => t.Id.ToString() == tenantId)
                        .Any()
                )
                .Select(u => new UserAccountDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    FirstName = u.Profile.FirstName,
                    LastName = u.Profile.LastName,
                    AvatarSrc = "https://i.pravatar.cc/300",
                    Roles = u.UserRoles.Select(u => u.Role).ToList()
                });

            return await Page<UserAccountDto>.From(usersSource, pageRequest);
        }

        public async Task<UserAccountDto> CreateUserAccount(string tenantId, UserAccount userAccount)
        {
            using var transaction = this._context.Database.BeginTransaction();

            try 
            {
                var userRole = await this._roleManager.FindByNameAsync(Roles.USER);
                var tenant = await this._context.Tenants.Where(tenant => tenant.Id.ToString() == tenantId).FirstOrDefaultAsync();

                if (tenant == null)
                {
                    throw new Exception("Error getting tenant for new user account");
                }

                userAccount.User.Tenants.Add(tenant);

                var userIdentityResult = await this._userManager.CreateAsync(userAccount.User, userAccount.RawPassword);
                
                if (!userIdentityResult.Succeeded)
                {
                    throw new Exception("Error creating new user!");
                }

                var addRoleIdentityResult = await this._userManager.AddToRoleAsync(userAccount.User, Roles.ADMIN);

                if (!addRoleIdentityResult.Succeeded)
                {
                    throw new Exception("Error adding role to new user");
                }

                transaction.Commit();

                return new UserAccountDto
                {
                    Id = userAccount.User.Id,
                    Email = userAccount.User.Email,
                    FirstName = userAccount.User.Profile.FirstName,
                    LastName = userAccount.User.Profile.LastName,
                    AvatarSrc = "https://i.pravatar.cc/300",
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

        public async Task<UserAccountDto> GetUserAccountByUserId(string userId)
        {
            var user = await this._context.Users
                .Include(u => u.Profile)
                .Include(u => u.UserRoles)
                .Where(u => u.Id.ToString() == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("User not found!");
            }

            return new UserAccountDto {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.Profile.FirstName,
                LastName = user.Profile.LastName,
                AvatarSrc = "https://i.pravatar.cc/300",
                Roles = user.UserRoles.Select(u => u.Role).ToList()
            };
        }
    }
}
