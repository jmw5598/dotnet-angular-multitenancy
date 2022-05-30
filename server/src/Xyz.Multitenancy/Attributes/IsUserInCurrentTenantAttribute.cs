using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Xyz.Multitenancy.Multitenancy;

namespace Xyz.Multitenancy.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class IsUserInCurrentTenantAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;

            if (httpContext != null)
            {
                var userClaimsPrinciple = httpContext.User;

                if (userClaimsPrinciple != null)
                {
                    string? tenantId = httpContext?.GetTenant()?.Guid;
                    string? tenantName = httpContext?.GetTenant()?.Name;

                    if (tenantId != null 
                            && (userClaimsPrinciple.HasClaim(MultiTenantConstants.TenantClaimSchema, tenantId)
                            || userClaimsPrinciple.HasClaim(MultiTenantConstants.TenantClaim, tenantId)))
                    {
                        context.Result = new UnauthorizedObjectResult(@$"User doesn't not have access to {tenantName}");
                    }
                }
            }
        }
    }
}
