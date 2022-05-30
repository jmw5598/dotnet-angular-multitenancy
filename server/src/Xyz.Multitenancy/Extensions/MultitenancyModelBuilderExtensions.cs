using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Models;

namespace Xyz.Multitenancy.Extensions
{
    public static class MultitenancyModelBuilderExtensions
    {
        public static void SeedDevTenant(this ModelBuilder modelBuilder)
        {
            var devCompanyConnectionString = "Server=localhost;Port=5432;Database=xyz_dev_company;User Id=xyz;Password=password;";

            var devPlan = new Plan
            {
                Id = Guid.NewGuid(),
                Name = "Dev",
                MaxUserCount = 5,
                Price = 0,
                RenewalRate = SubscriptionRenewalRate.MONTHLY
            };

            var company = new Company
            {
                Id = Guid.NewGuid(),
                Name = "Dev Company"
            };

            var tenantPlan = new TenantPlan
            {
                Id = Guid.NewGuid(),
                MaxUserCount = devPlan.MaxUserCount,
                Price = devPlan.Price,
                RenewalRate = devPlan.RenewalRate,
                PlanId = devPlan.Id
            };

            var tenant = new Tenant
            {
                Id = Guid.NewGuid(),
                Name = company.Name.Trim().ToLower().Replace(" ", ""),
                DisplayName = company.Name,
                DomainNames = "",
                IpAddresses = "",
                ConnectionString = devCompanyConnectionString,
                Guid = Guid.NewGuid().ToString(),
                IsActive = true,
                IsConfigured = true,
                CompanyId = company.Id,
                TenantPlanId = tenantPlan.Id
            };

            
            

            modelBuilder.Entity<Plan>().HasData(devPlan);
            modelBuilder.Entity<Company>().HasData(company);
            modelBuilder.Entity<Tenant>().HasData(tenant);
            modelBuilder.Entity<TenantPlan>().HasData(tenantPlan);
        }

        public static void SeedPlans(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>().HasData(
                new Plan {
                    Id = Guid.NewGuid(),
                    Name = "Free",
                    Price = 0.00M,
                    RenewalRate = SubscriptionRenewalRate.MONTHLY,
                    MaxUserCount = 5
                }
            );
        }

        public static void SeedDevLocalhostTenant(this ModelBuilder modelBuilder)
        {
            var localhostCompanyConnectionString = "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;";

            var company = new Company
            {
                Id = Guid.NewGuid(),
                Name = "Localhost"
            };

            var plan = new Plan
            {
                Id = Guid.NewGuid(),
                MaxUserCount = 5,
                Name = "Localhost Dev Plan",
                Price = 0,
                RenewalRate = SubscriptionRenewalRate.MONTHLY
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
            modelBuilder.Entity<Plan>().HasData(plan);
            modelBuilder.Entity<TenantPlan>().HasData(tenantPlan);
            modelBuilder.Entity<Tenant>().HasData(tenant);
        }
    }
}