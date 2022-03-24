using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Xyz.Core.Interfaces
{
    public interface ITokenService
    {
        public Task<JwtSecurityToken> CreateJwtSecurityToken(IEnumerable<Claim> claims);
        public Task<IEnumerable<Claim>> DecodeJwtSecurityToken(JwtSecurityToken token);
    }
}
