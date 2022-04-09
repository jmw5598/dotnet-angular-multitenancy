using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Xyz.Multitenancy.Extensions;
using Xyz.Core.Entities.Multitenancy;

namespace Xyz.Multitenancy.Data
{
    public class AuthenticationDbContext : IdentityDbContext<
        ApplicationUser, 
        ApplicationRole, 
        Guid, 
        IdentityUserClaim<Guid>,
        ApplicationUserRole, 
        IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>, 
        IdentityUserToken<Guid>
    >
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
            modelBuilder.HandleCustomIdentityTableMapping();
            
            modelBuilder.SeedDevLocalhostTenant(); // For Dev only
            modelBuilder.SeedDevUserAccount();  // For Dev only
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
