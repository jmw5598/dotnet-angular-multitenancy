using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Models;
using Xyz.Core.Interfaces;
using Xyz.Multitenancy.Data;

namespace Xyz.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private ILogger<AuthenticationService> _logger;
        private IConfiguration _configuration;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        private AuthenticationDbContext _context;
        private ITokenService _tokenService;

        public AuthenticationService(
            ILogger<AuthenticationService> logger, 
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            AuthenticationDbContext context,
            ITokenService tokenService)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._context = context;
            this._tokenService = tokenService;
        }

        public async Task<AuthenticatedUser> Login(Credentials credentials)
        {
            var user = await this._userManager.FindByNameAsync(credentials.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, credentials.Password))
            {
                // @TODO Check if user is active and tenant is active

                // Get roles
                var userRoles = await this._userManager.GetRolesAsync(user);

                // Get claims
                // public tenants = this._context.Tenants.Fin

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = await this._tokenService.CreateJwtSecurityToken(authClaims);

                return new AuthenticatedUser
                {
                    Status = AuthenticatedStatus.AUTHENTICATED,
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    // @TODO actually create a refresh token
                    RefreshToken = Guid.NewGuid().ToString()
                };
            }
            
            return null;
        }

        public async Task<object> Register(Registration registration)
        {
            using var transaction = this._context.Database.BeginTransaction();

            try 
            {
                // create tenant entry (subdomain? should this be in the registraiton form?)
                // create company,
                // create company_tenant entry
                // create profile

                // create user with company and profile and tenant

                // save user

                // create user_tenant entry

                // commit transation

                // var registeredUser = await this._userManager.CreateAsync(
                //     new ApplicationUser
                //     {
                //         UserName = "jmw5598@gmail.com",
                //         Email = "jmw5598@gmail.com",
                //         EmailConfirmed = true
                //     }, "Password@123");

                // Look into how to seed roles?
                //this._roleManager.
                // throw new Exception("Error registering new account!");
                return new ResponseMessage
                {
                    Status = ResponseStatus.SUCCESS,
                    Message = "Your account was create!\n  Please check your email for a confirmation!"
                }; //registeredUser == null ? new {} : registeredUser;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                this._logger.LogError("Error registering new account!");
                throw new Exception("Error registering new account!");
            }
        }

        public async Task<object> ForgotPassword()
        {
            return await Task.FromResult(new {});
        }

        public async Task<object> ChangePassword()
        {
            return await Task.FromResult(new {});
        }
    }
}