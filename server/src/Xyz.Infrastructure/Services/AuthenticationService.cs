using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;

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
                var role = await this._roleManager.FindByNameAsync(Roles.ADMIN);

                var plan = this._context.Plans.Find(registration.Plan.Id);

                if (plan == null)
                {
                    throw new Exception("Error finding selected plan!");
                }

                var tenant = new Tenant
                {
                    Name = registration.Company.Name.ToLower().Replace(" " , ""),
                    DisplayName = registration.Company.Name,
                    Guid = Guid.NewGuid().ToString(),
                    Company = registration.Company,
                    IsActive = false,
                    IsConfigured = false,
                    TenantPlan = new TenantPlan
                    {
                        MaxUserCount = plan.MaxUserCount,
                        PlanId = plan.Id,
                        Price = plan.Price,
                        RenewalRate = plan.RenewalRate
                    },
                    DomainNames = "",
                    ConnectionString = "",
                    IpAddresses = ""
                };

                registration.User.Tenants = new List<Tenant>{ tenant };
                registration.User.Profile = registration.Profile;

                var userIdentityResult = await this._userManager.CreateAsync(registration.User, registration.RawPassword);
                
                if (!userIdentityResult.Succeeded)
                {
                    throw new Exception("Error creating new user!");
                }

                var addRoleIdentityResult = await this._userManager.AddToRoleAsync(registration.User, Roles.ADMIN);

                if (!addRoleIdentityResult.Succeeded)
                {
                    throw new Exception("Error adding role to new user");
                }

                transaction.Commit();

                return new ResponseMessage
                {
                    Status = ResponseStatus.SUCCESS,
                    Message = "Your account was create!\n  Please check your email for a confirmation!"
                };
            }
            catch (Exception e)
            {
                transaction.Rollback();
                this._logger.LogError("Error registering new account!", e);
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