using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Xyz.Core.Entities;
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
        private RoleManager<IdentityRole> _roleManager;
        private AuthenticationDbContext _context;


        public AuthenticationService(
            ILogger<AuthenticationService> logger, 
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AuthenticationDbContext context)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._context = context;
        }

        public async Task<object> Login(Credentials credentials)
        {
            var user = await this._userManager.FindByNameAsync(credentials.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, credentials.Password))
            {
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

                var token = this.CreateAccessToken(authClaims);

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

        public async Task<object> Register()
        {
            // var registeredUser = await this._userManager.CreateAsync(
            //     new ApplicationUser
            //     {
            //         UserName = "jmw5598@gmail.com",
            //         Email = "jmw5598@gmail.com",
            //         EmailConfirmed = true
            //     }, "Password@123");

            return new {}; //registeredUser == null ? new {} : registeredUser;
        }

        public async Task<object> ForgotPassword()
        {
            return new {};
        }

        public async Task<object> ChangePassword()
        {
            return new {};
        }

        // @TODO move this to a token service??
        // May need methods to decdoe token also.
        private JwtSecurityToken CreateAccessToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: this._configuration["JWT:ValidIssuer"],
                audience: this._configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}