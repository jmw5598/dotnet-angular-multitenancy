using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

namespace Xyz.Core.Interfaces.Tenants
{
    public interface ITokenService
    {
        public Task<JwtSecurityToken> CreateJwtSecurityTokenAsync(IEnumerable<Claim> claims);
        public Task<JwtSecurityToken> DecodeJwtSecurityTokenAsync(string token);
        public Task<bool> IsValidJwtSecurityTokenAsync(string token);
    }
}
