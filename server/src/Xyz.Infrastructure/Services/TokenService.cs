using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using Xyz.Core.Interfaces;

namespace Xyz.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _jwtSecrityKey = "JWT:Secret";
        private readonly string _jwtValidIssuerKey = "JWT:ValidIssuer";
        private readonly string _jwtValidAudienceKey = "JWT:ValidAudience";

        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<JwtSecurityToken> CreateJwtSecurityToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this._configuration[this._jwtSecrityKey]));

            var token = new JwtSecurityToken(
                issuer: this._configuration[this._jwtValidIssuerKey],
                audience: this._configuration[this._jwtValidAudienceKey],
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        public async Task<IEnumerable<Claim>> DecodeJwtSecurityToken(JwtSecurityToken token)
        {
            return null;
        }
    }
}