using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using Xyz.Multitenancy.Multitenancy;

namespace Xyz.Multitenancy.Security
{
    public class InCurrentTenantRequirement : AuthorizationHandler<InCurrentTenantRequirement>, IAuthorizationRequirement
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InCurrentTenantRequirement(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, InCurrentTenantRequirement requirement)
        {
            var tenantId = _httpContextAccessor.HttpContext.GetTenant().Guid;

            if (context.User.HasClaim(MultiTenantConstants.TenantClaim, tenantId) 
                || context.User.HasClaim(MultiTenantConstants.TenantClaimSchema, tenantId))
            {
                context.Succeed(requirement);
            }

            return Task.FromResult(0);
        }
    }
}
