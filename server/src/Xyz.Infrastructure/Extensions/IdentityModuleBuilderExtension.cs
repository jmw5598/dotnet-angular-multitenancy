using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using Xyz.Core.Entities.Identity;
using Xyz.Core.Entities.Tenant;
using Xyz.Infrastructure.Seeds;

namespace Xyz.Infrastructure.Extensions
{
    public static class IdentityModelBuilderExtensions
    {
        public static void HandleCustomIdentityTableMapping(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.ToTable("asp_net_user_roles");
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId);
            });

            modelBuilder.Entity<ApplicationUser>(user => 
            {
                user.ToTable("asp_net_users");
            });

            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("asp_net_user_tokens");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("asp_net_user_logins");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("asp_net_user_claims");
            modelBuilder.Entity<ApplicationRole>().ToTable("asp_net_roles");

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("asp_net_role_claims");
        }

        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            var seedRoles = ApplicationRolesSeed.Get();
            modelBuilder.Entity<ApplicationRole>().HasData(seedRoles);
        }

        public static void SeedDevUser(this ModelBuilder modelBuilder)
        {
            var seedRoles = ApplicationRolesSeed.Get();

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

            modelBuilder.Entity<ApplicationRole>().HasData(seedRoles);
            modelBuilder.Entity<Profile>().HasData(profile);
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            // Create User Module Permissions And User Permissions
            var userModulePermissionsAndUserPermisions = UserModulePermissionsAndUserPermissionsSeed.Get(user.Id.ToString());
            
            modelBuilder.Entity<UserModulePermission>().HasData(
                userModulePermissionsAndUserPermisions.UserModulePermissions
            );
            modelBuilder.Entity<UserPermission>().HasData(
                userModulePermissionsAndUserPermisions.UserPermissions
            );

            // Set Roles For User
            modelBuilder.Entity<ApplicationUserRole>().HasData(
                seedRoles.Select(role => 
                    new ApplicationUserRole
                    {
                        RoleId = role.Id,
                        UserId = user.Id
                    }
                ).ToList()
            );
        }
    }
}