using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Identity;
using Xyz.Core.Models.Tenants;
using Xyz.Core.Interfaces.Tenants;
using Xyz.Infrastructure.Data;
using Xyz.Multitenancy.Multitenancy;

namespace Xyz.Infrastructure.Services.Tenants
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ITokenService _tokenService;
        private readonly ITenantAccessor<Tenant> _tenantAccessor;
        private readonly IEmailingService _emailingService;

        public AuthenticationService(
            ILogger<AuthenticationService> logger, 
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext applicationDbContext,
            ITokenService tokenService,
            ITenantAccessor<Tenant> tenanatAccessor,
            IEmailingService emailingService)
        {
            this._logger = logger;
            this._userManager = userManager;
            this._applicationDbContext = applicationDbContext;
            this._tokenService = tokenService;
            this._tenantAccessor = tenanatAccessor;
            this._emailingService = emailingService;
        }

        public async Task<AuthenticatedUser> LoginAsync(Credentials credentials)
        {
            var tenant = this._tenantAccessor.Tenant;

            if (tenant == null || !tenant.IsActive || !tenant.IsActive)
            {
                throw new Exception("Account is still being setup or is inactive! Please try again later!");
            }

            var user = await this._userManager.FindByNameAsync(credentials.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, credentials.Password))
            {                
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(MultiTenantConstants.TenantClaim, tenant.Guid)
                };

                var userRoles = await this._userManager.GetRolesAsync(user);

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = await this._tokenService.CreateJwtSecurityTokenAsync(authClaims);

                var savedRefreshToken = await this._applicationDbContext.RefreshTokens
                    .Where(t => t.UserId.ToString() == user.Id.ToString() && !t.IsBlacklisted)
                    .FirstOrDefaultAsync();

                if (savedRefreshToken == null)
                {
                    savedRefreshToken = new RefreshToken { UserId = user.Id };
                    this._applicationDbContext.RefreshTokens.Add(savedRefreshToken);
                    await this._applicationDbContext.SaveChangesAsync();
                }

                return new AuthenticatedUser
                {
                    Status = AuthenticatedStatus.AUTHENTICATED,
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = savedRefreshToken.Token.ToString()
                };
            }
            
            return null;
        }

        public async Task<object> ForgotPasswordAsync()
        {
            var emailRequest = new EmailRequest
            {
                To = "fonziebononzie@gmail.com",
                Subject = "Testing",
                Body = "Testing Body"
            };
            await this._emailingService.SendEmailAsync(emailRequest);
            return await Task.FromResult(new {});
        }

        public async Task<object> ChangePasswordAsync()
        {
            return await Task.FromResult(new {});
        }

        public async Task<AuthenticatedUser> RefreshAccessTokenAsync(RefreshTokenRequest refreshTokenRequest)
        {
            try 
            {
                var isAccessTokenValid = await this._tokenService
                    .IsValidJwtSecurityTokenAsync(refreshTokenRequest.AccessToken);

                if (!isAccessTokenValid)
                {
                    throw new Exception("Unable to refresh access token, the supplied access token was invalid!");
                }

                var savedRefreshToken = await this._applicationDbContext.RefreshTokens
                    .Where(t => t.Token.ToString() == refreshTokenRequest.RefreshToken && !t.IsBlacklisted)
                    .FirstOrDefaultAsync();

                if (savedRefreshToken == null)
                {
                    throw new Exception("Unable to refresh access token, the supplied refresh token was invalid!");
                }

                var decodedAccessToken = await this._tokenService.DecodeJwtSecurityTokenAsync(refreshTokenRequest.AccessToken);

                if (decodedAccessToken == null)
                {
                    throw new Exception("Unable to refresh access token, decoding existing token failed!");
                }

                var authClaims = decodedAccessToken.Claims.ToList();

                var token = await this._tokenService.CreateJwtSecurityTokenAsync(authClaims);

                return new AuthenticatedUser
                {
                    Status = AuthenticatedStatus.AUTHENTICATED,
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = savedRefreshToken.Token.ToString()
                };
            }
            catch (Exception ex)
            {
                var errorMessage = "Error refreshing access token!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                throw;
            }
        }
    }   
}