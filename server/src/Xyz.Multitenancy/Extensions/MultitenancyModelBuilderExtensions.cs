using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Models;

namespace Xyz.Multitenancy.Extensions
{
    public static class MultitenancyModelBuilderExtensions
    {
        public static void SeedApplicationUsersAndRoles(this ModelBuilder modelBuilder)
        {
            // Create Roles
            var rootRole = new ApplicationRole { 
                Id = Guid.NewGuid(),
                Name = Roles.ROOT, 
                NormalizedName = Roles.ROOT 
            };

            var adminRole = new ApplicationRole { 
                Id = Guid.NewGuid(), 
                Name = Roles.ADMIN, 
                NormalizedName = Roles.ADMIN
            };

            var userRole = new ApplicationRole { 
                Id = Guid.NewGuid(),
                Name = Roles.USER, 
                NormalizedName = Roles.USER 
            };

            modelBuilder.Entity<ApplicationRole>().HasData(rootRole, adminRole, userRole);
    
            // Create User
            var user = new ApplicationUser { 
                Id = Guid.NewGuid(),
                Email = "jmw5598@gmail.com",
                NormalizedEmail = "JMW5598@gmail.com",
                EmailConfirmed = true,
                UserName = "jmw5598@gmail.com",
                NormalizedUserName = "JMW5598@GMAIL.COM"
            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = ph.HashPassword(user, "Password@123");

            modelBuilder.Entity<ApplicationUser>().HasData(user);

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
    }
}