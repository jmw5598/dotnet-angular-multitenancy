﻿using Microsoft.AspNetCore.Http;

using Xyz.Core.Entities.Multitenancy;

namespace Xyz.Multitenancy.Multitenancy
{
    internal class TenantMiddleware<T> where T : Tenant
    {
        private readonly RequestDelegate next;

        public TenantMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Items.ContainsKey(MultiTenantConstants.HttpContextTenantKey))
            {
                var tenantService = context.RequestServices.GetService(typeof(TenantAccessService<T>)) as TenantAccessService<T>;
                if (tenantService != null)
                {
                    context.Items.Add(MultiTenantConstants.HttpContextTenantKey, await tenantService.GetTenantAsync());
                }
            }

            //Continue processing
            if (next != null)
                await next(context);
        }
    }
}
