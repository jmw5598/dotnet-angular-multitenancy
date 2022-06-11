using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Xyz.Multitenancy.Multitenancy;
using Xyz.Multitenancy.Data;
using Xyz.Infrastructure.Data;
using Xyz.Core.Models;

namespace Xyz.Api.Security
{
    public class TenantCanCreateUserRequirement : AuthorizationHandler<TenantCanCreateUserRequirement>, IAuthorizationRequirement
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantCanCreateUserRequirement(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, TenantCanCreateUserRequirement requirement)
        {
            var multitenancyDbContext = this._httpContextAccessor.HttpContext
                ?.RequestServices.GetService(typeof(MultitenancyDbContext)) as MultitenancyDbContext;
            
            var applicationDbContext = this._httpContextAccessor.HttpContext
                ?.RequestServices.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            
            string? tenantId = _httpContextAccessor.HttpContext?.GetTenant()?.Id.ToString();

            if (multitenancyDbContext != null && applicationDbContext != null)
            {
                var maxUsersAllowed = await multitenancyDbContext.Tenants
                    .Include(tenant => tenant.TenantPlan)
                    .Where(tenant => tenant.Id.ToString() == tenantId)
                    .Select(tenant => tenant.TenantPlan.MaxUserCount)
                    .FirstOrDefaultAsync();

                var currentTotalUserCount = await applicationDbContext.Users
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .Include(u => u.Profile)
                    .Where(user => !user.UserRoles.Any(ur => ur.Role.Name == Roles.ADMIN))
                    .CountAsync();
                
                if(currentTotalUserCount < maxUsersAllowed)
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
}
