using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Models;

namespace Xyz.Multitenancy.Extensions
{
    public static class MultitenancyModelBuilderExtensions
    {
        public static void SeedDevUserAccount(this ModelBuilder modelBuilder)
        {
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
                ConnectionString = "TODO",
                Guid = Guid.NewGuid().ToString(),
                IsActive = true,
                IsConfigured = true,
                CompanyId = company.Id,
                TenantPlanId = tenantPlan.Id
            };

            var rootRole = new ApplicationRole 
            { 
                Id = Guid.NewGuid(),
                Name = Roles.ROOT, 
                NormalizedName = Roles.ROOT 
            };

            var adminRole = new ApplicationRole 
            {
                Id = Guid.NewGuid(), 
                Name = Roles.ADMIN, 
                NormalizedName = Roles.ADMIN
            };

            var userRole = new ApplicationRole
            { 
                Id = Guid.NewGuid(),
                Name = Roles.USER, 
                NormalizedName = Roles.USER
            };

            var profile = new Profile
            {
                Id = Guid.NewGuid(),
                FirstName = "Jason",
                LastName = "White"
            };

            var user = new ApplicationUser { 
                Id = Guid.NewGuid(),
                Email = "jmw5598@gmail.com",
                NormalizedEmail = "JMW5598@gmail.com",
                EmailConfirmed = true,
                UserName = "jmw5598@gmail.com",
                NormalizedUserName = "JMW5598@GMAIL.COM",
                ProfileId = profile.Id
            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = ph.HashPassword(user, "Password@123");
            

            modelBuilder.Entity<Plan>().HasData(devPlan);
            modelBuilder.Entity<Company>().HasData(company);
            modelBuilder.Entity<Tenant>().HasData(tenant);
            modelBuilder.Entity<TenantPlan>().HasData(tenantPlan);
            modelBuilder.Entity<ApplicationRole>().HasData(rootRole, adminRole, userRole);
            modelBuilder.Entity<Profile>().HasData(profile);
            modelBuilder.Entity<ApplicationUser>().HasData(user);
            modelBuilder.Entity("user_tenants").HasData(new { TenantId = tenant.Id, AspNetUserId = user.Id });

            // Set Roles For User
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid> { 
                    RoleId = rootRole.Id, 
                    UserId = user.Id 
                },
                new IdentityUserRole<Guid> { 
                    RoleId = adminRole.Id, 
                    UserId = user.Id 
                },
                new IdentityUserRole<Guid> { 
                    RoleId = userRole.Id, 
                    UserId = user.Id 
                }
            );
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
                ConnectionString = ""
            };
            
            modelBuilder.Entity<Company>().HasData(company);
            modelBuilder.Entity<Plan>().HasData(plan);
            modelBuilder.Entity<TenantPlan>().HasData(tenantPlan);
            modelBuilder.Entity<Tenant>().HasData(tenant);
        }

        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            var rootRole = new ApplicationRole 
            { 
                Id = Guid.NewGuid(),
                Name = Roles.ROOT, 
                NormalizedName = Roles.ROOT 
            };

            var adminRole = new ApplicationRole 
            {
                Id = Guid.NewGuid(), 
                Name = Roles.ADMIN, 
                NormalizedName = Roles.ADMIN
            };

            var userRole = new ApplicationRole
            { 
                Id = Guid.NewGuid(),
                Name = Roles.USER, 
                NormalizedName = Roles.USER
            };

            modelBuilder.Entity<ApplicationRole>().HasData(rootRole, adminRole, userRole);
        }
    }
}