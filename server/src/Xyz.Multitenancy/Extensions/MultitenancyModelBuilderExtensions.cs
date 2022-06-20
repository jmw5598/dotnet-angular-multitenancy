using Microsoft.EntityFrameworkCore;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Models.Multitenancy;

using Xyz.Multitenancy.Seeds;

namespace Xyz.Multitenancy.Extensions
{
    public static class MultitenancyModelBuilderExtensions
    {
        public static void SeedPlans(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>().HasData(PlansSeed.Get());
        }

        public static void SeedDevLocalhostTenant(this ModelBuilder modelBuilder)
        {
            var localhostCompanyConnectionString = "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;";

            var company = new Company
            {
                Id = Guid.NewGuid(),
                Name = "Localhost"
            };

            var plan = PlansSeed.Get().FirstOrDefault() ?? new Plan {
                Id = new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"),
                Name = "Free",
                Price = 0.00M,
                PaymentRequired = false,
                RenewalRate = SubscriptionRenewalRate.MONTHLY,
                MaxUserCount = 2
            };

            var tenantPlan = new TenantPlan
            {
                Id = Guid.NewGuid(),
                MaxUserCount = plan.MaxUserCount,
                Price = plan.Price,
                RenewalRate = SubscriptionRenewalRate.MONTHLY,
                PlanId = plan.Id
            };
            
            var tenant = new Tenant
            {
                Id = Guid.NewGuid(),
                CompanyId = company.Id,
                DisplayName = company.Name,
                DomainNames = "",
                Guid = Guid.NewGuid().ToString(),
                IpAddresses = "",
                IsActive = false,
                IsConfigured = false,
                Name = company.Name.Trim().ToLower(),
                TenantPlanId = tenantPlan.Id,
                ConnectionString = localhostCompanyConnectionString
            };
            
            modelBuilder.Entity<Company>().HasData(company);
            modelBuilder.Entity<TenantPlan>().HasData(tenantPlan);
            modelBuilder.Entity<Tenant>().HasData(tenant);
        }
    }
}