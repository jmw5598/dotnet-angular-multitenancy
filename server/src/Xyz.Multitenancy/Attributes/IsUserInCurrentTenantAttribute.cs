using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Xyz.Core.Entities.Multitenancy;
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
                var signInManager = httpContext.RequestServices.GetService(typeof(Microsoft.AspNetCore.Identity.SignInManager<ApplicationUser>)) as SignInManager<ApplicationUser>;
                var userClaimsPrinciple = httpContext.User;

                if (userClaimsPrinciple != null && signInManager.IsSignedIn(userClaimsPrinciple))
                {
                    var tenantId = httpContext.GetTenant().Guid;
                    var tenantName = httpContext.GetTenant().Name;

                    if (userClaimsPrinciple.HasClaim(MultiTenantConstants.TenantClaimSchema, tenantId)
                            || userClaimsPrinciple.HasClaim(MultiTenantConstants.TenantClaim, tenantId))
                    {
                        context.Result = new UnauthorizedObjectResult(@$"User doesn't not have access to {tenantName}");
                    }
                }
            }
        }
    }
}
