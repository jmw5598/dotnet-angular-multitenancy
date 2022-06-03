using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Xyz.Core.Interfaces;

namespace Xyz.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly ILogger<TokenService> _logger;
        private readonly string _jwtSecrityKey = "JWT:Secret";
        private readonly string _jwtValidIssuerKey = "JWT:ValidIssuer";
        private readonly string _jwtValidAudienceKey = "JWT:ValidAudience";

        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration, ILogger<TokenService> logger)
        {
            this._logger = logger;
            this._configuration = configuration;
        }

        public async Task<JwtSecurityToken> CreateJwtSecurityToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this._configuration[this._jwtSecrityKey]));

            var token = new JwtSecurityToken(
                issuer: this._configuration[this._jwtValidIssuerKey],
                audience: this._configuration[this._jwtValidAudienceKey],
                expires: DateTime.UtcNow.AddMinutes(15),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        public async Task<JwtSecurityToken> DecodeJwtSecurityToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this._configuration[this._jwtSecrityKey]));

            try
            {
                return tokenHandler.ReadJwtToken(token);
            }
            catch (Exception e)
            {
                this._logger.LogError("Error decoding of security token", new { Exeception = e.Message });
                throw;
            }
        }

        public async Task<bool> IsValidJwtSecurityToken(string token)
        {
            if (token == null) return false;

            var tokenHandler = new JwtSecurityTokenHandler();
            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this._configuration[this._jwtSecrityKey]));

            try
            {
                tokenHandler.ValidateToken(
                    token, 
                    new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = authSigningKey,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero,
                        ValidateLifetime = false 
                    }, 
                    out SecurityToken validatedToken);
                return validatedToken != null;
            }
            catch (Exception e)
            {
                this._logger.LogError("Error checking validity of security token", new { Exeception = e.Message });
                return false;
            }
        }
    }
}