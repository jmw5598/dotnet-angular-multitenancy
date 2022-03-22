using Microsoft.Extensions.Logging;

using Xyz.Core.Models;
using Xyz.Core.Interfaces;
using Xyz.Multitenancy.Data;

namespace Xyz.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private ILogger<AuthenticationService> _logger;
        private AuthenticationDbContext _context;


        public AuthenticationService(ILogger<AuthenticationService> logger, AuthenticationDbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<object> Login(Credentials credentials)
        {
            return credentials;
        }

        public async Task<object> Register()
        {
            return new {};
        }

        public async Task<object> ForgotPassword()
        {
            return new {};
        }

        public async Task<object> ChangePassword()
        {
            return new {};
        }
    }
}