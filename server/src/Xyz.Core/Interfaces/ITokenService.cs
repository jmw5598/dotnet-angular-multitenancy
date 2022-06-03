using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

namespace Xyz.Core.Interfaces
{
    public interface ITokenService
    {
        public Task<JwtSecurityToken> CreateJwtSecurityToken(IEnumerable<Claim> claims);
        public Task<JwtSecurityToken> DecodeJwtSecurityToken(string token);
        public Task<bool> IsValidJwtSecurityToken(string token);
    }
}
