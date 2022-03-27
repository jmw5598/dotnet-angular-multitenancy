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
            return await Task.FromResult(
                new ValidationResult
                {
                    IsValid = true
                }
            );
        }

        public async Task<ValidationResult> VerifyUserName(string userName)
        {
            // @TODO
            return await Task.FromResult(
                new ValidationResult
                {
                    IsValid = true
                }
            );
        }
    }
}
