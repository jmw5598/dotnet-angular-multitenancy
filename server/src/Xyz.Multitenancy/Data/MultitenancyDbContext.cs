using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using Xyz.Multitenancy.Extensions;
using Xyz.Core.Entities.Multitenancy;

namespace Xyz.Multitenancy.Data
{
    public class MultitenancyDbContext : DbContext
    {
        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<Plan> Plans => Set<Plan>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<TenantPlan> TenantPlans => Set<TenantPlan>();
        public DbSet<BillingInvoice> BillingInvoices => Set<BillingInvoice>();

        public MultitenancyDbContext(DbContextOptions<MultitenancyDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedPlans();
            modelBuilder.SeedDevLocalhostTenant();
        }

        /// <summary>
        /// Taken from here: https://medium.com/oppr/net-core-using-entity-framework-core-in-a-separate-project-e8636f9dc9e5
        /// </summary>
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MultitenancyDbContext>
        {
            public MultitenancyDbContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Xyz.Multitenancy/config.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<MultitenancyDbContext>();
                var connectionString = configuration.GetConnectionString("XyzMultitenancy");
                builder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();;

                return new MultitenancyDbContext(builder.Options);
            }
        }
    }
}
