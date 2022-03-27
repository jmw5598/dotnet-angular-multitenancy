using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Xyz.Multitenancy.Extensions;
using Xyz.Core.Entities.Multitenancy;

namespace Xyz.Multitenancy.Data
{
    public class AuthenticationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<Plan> Plans => Set<Plan>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Profile> Profiles => Set<Profile>();
        public DbSet<TenantPlan> TenantPlans => Set<TenantPlan>();

        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("asp_net_users");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("asp_net_user_tokens");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("asp_net_user_logins");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("asp_net_user_claims");
            modelBuilder.Entity<ApplicationRole>().ToTable("asp_net_roles");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("asp_net_user_roles");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("asp_net_role_claims");

            modelBuilder.Entity<ApplicationUser>()
             .HasMany(x => x.Tenants)
             .WithMany(x => x.Users)
             .UsingEntity<Dictionary<string, object>>("user_tenants",
                 x => x.HasOne<Tenant>().WithMany().HasForeignKey("TenantId"),
                 x => x.HasOne<ApplicationUser>().WithMany().HasForeignKey("AspNetUserId"),
                 x => x.ToTable("user_tenants"));

            modelBuilder.SeedApplicationUsersAndRoles();
            modelBuilder.SeedPlans();
        }

        /// <summary>
        /// Taken from here: https://medium.com/oppr/net-core-using-entity-framework-core-in-a-separate-project-e8636f9dc9e5
        /// </summary>
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AuthenticationDbContext>
        {
            public AuthenticationDbContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Xyz.Multitenancy/config.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<AuthenticationDbContext>();
                var connectionString = configuration.GetConnectionString("XyzMultitenancy");
                builder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();;

                return new AuthenticationDbContext(builder.Options);
            }
        }
    }
}
