using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

using Xyz.Core.Entities;
using Xyz.Core.Models;
using Xyz.Core.Interfaces;
using Xyz.Multitenancy.Data;

namespace Xyz.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private ILogger<AuthenticationService> _logger;
        private UserManager<ApplicationUser> _userManager;
        private AuthenticationDbContext _context;


        public AuthenticationService(
            ILogger<AuthenticationService> logger, 
            UserManager<ApplicationUser> userManager,
            AuthenticationDbContext context)
        {
            this._logger = logger;
            this._userManager = userManager;
            this._context = context;
        }

        public async Task<object> Login(Credentials credentials)
        {
            var user = await this._userManager.FindByNameAsync(credentials.UserName);
            var isPasswordValid = false;

            if (user != null)
            {
                isPasswordValid = await this._userManager.CheckPasswordAsync(user, credentials.Password);
            }

            return credentials;
        }

        public async Task<object> Register()
        {
            var registeredUser = await this._userManager.CreateAsync(
                new ApplicationUser
                {
                    UserName = "jmw5598@gmail.com",
                    Email = "jmw5598@gmail.com",
                    EmailConfirmed = true
                }, "Password@123");
            return registeredUser == null ? new {} : registeredUser;
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