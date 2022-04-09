using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

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

        public UsersService(ILogger<UsersService> logger, AuthenticationDbContext context)
        {
            this._logger = logger;
            this._context = context;
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

        public async Task<Page<UserDto>> SearchUsersByTenant(string tenantId, PageRequest pageRequest)
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
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    FirstName = u.Profile.FirstName,
                    LastName = u.Profile.LastName,
                    Roles = u.UserRoles.Select(u => u.Role).ToList()
                });

            return await Page<UserDto>.From(usersSource, pageRequest);
        }
    }
}
