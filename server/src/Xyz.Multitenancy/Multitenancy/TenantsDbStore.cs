﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Multitenancy.Data;

namespace Xyz.Multitenancy.Multitenancy
{
    public class TenantsDbStore : ITenantStore<Tenant>
    {
        private readonly MultitenancyDbContext _authenticationDbContext;
        private readonly IConfiguration _configuration;
        private readonly ILogger<TenantsDbStore> _logger;

        public TenantsDbStore(MultitenancyDbContext authenticationDbContext, IConfiguration configuration, ILogger<TenantsDbStore> logger)
        {
            _authenticationDbContext = authenticationDbContext;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<Tenant> GetTenantAsync(string domainName, string ipAddress, string name)
        {
            Tenant? tenant = null;

            if (string.IsNullOrWhiteSpace(name))
            {
                tenant = TryGetTenantFromDomainName(domainName, ipAddress);
            }
            else
            {
                try
                {
                    tenant = _authenticationDbContext.Tenants.SingleOrDefault(tenant => tenant.Name.ToLower() == name.ToLower());
                }
                catch (Exception ex)
                {
                    _logger.LogError($"There were multiple tenants which have the same domain name that was being looked up. Domain names must be unique.", ex);
                    tenant = TryGetTenantFromDomainName(domainName, ipAddress);
                }
            }

            if (tenant == null)
            {
                tenant = GetDefaultTenant();
            }

            if (tenant == null)
            {
                throw new NullReferenceException($"The tenant could not be found in the store. With DomainName: {domainName}, IpAddress: {ipAddress}, Name: {name}");
            }

            return await Task.FromResult(tenant);
        }

        private Tenant? TryGetTenantFromDomainName(string domainName, string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                return TryGetTenantFromIp(ipAddress);
            }
            else
            {
                Tenant? tenant = null;

                try
                {
                    tenant = _authenticationDbContext.Tenants.SingleOrDefault(tenant => tenant.DomainNames.CommaDelimitedStringToList().Any(domainName0 => domainName0 == domainName));
                }
                catch (Exception ex)
                {
                    _logger.LogError($"There were multiple tenants which have the same domain name that was being looked up. Domain names must be unique.", ex);
                    return TryGetTenantFromIp(ipAddress);
                }


                if (tenant == null)
                {
                    return TryGetTenantFromIp(ipAddress);
                }
                else
                {
                    return tenant;
                }
            }
        }

        private Tenant? TryGetTenantFromIp(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                return GetDefaultTenant();
            }
            else
            {
                Tenant? tenant = null;

                try
                {
                    tenant = _authenticationDbContext.Tenants.SingleOrDefault(tenant => tenant.IpAddresses.CommaDelimitedStringToList().Any(ipAddress0 => ipAddress0 == ipAddress));
                }
                catch (Exception ex)
                {
                    _logger.LogError($"There were multiple tenants which have the same ip address that was being looked up. Ip Addresses must be unique.", ex);
                    return GetDefaultTenant();
                }


                if (tenant == null)
                {
                    return GetDefaultTenant();
                }
                else
                {
                    return tenant;
                }
            }
        }

        private Tenant? GetDefaultTenant()
        {
            var defaultTenantName = _configuration.GetValue<string>("DefaultTenant");
            return _authenticationDbContext.Tenants.SingleOrDefault(tenant => tenant.Name == defaultTenantName);
        }
    }
}
