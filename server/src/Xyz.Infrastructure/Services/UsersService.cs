using Microsoft.Extensions.Logging;

using Xyz.Multitenancy.Data;
using Xyz.Core.Interfaces;
using Xyz.Core.Models;

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

        public async Task<object> GetUserSettings(string userId)
        {
            return new {}; // @TODO
        }

        public async Task<object> GetUserPermissions(string userId)
        {
            return new {}; // @TODO
        }
    }
}
