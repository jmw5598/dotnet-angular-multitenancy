using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;

using Xyz.Multitenancy.Models;
using Xyz.Multitenancy.Multitenancy;
using Xyz.Core.Entities;

namespace Xyz.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOptions<TenantsConfiguration> _configuration;


        // Entity Datasets
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }


        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<TenantsConfiguration> configuration,
            ITenantAccessor<Tenant> tenantAccessor) : base(CreateDbContextOptions(tenantAccessor, configuration))
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        

        private static DbContextOptions CreateDbContextOptions(ITenantAccessor<Tenant> tenantAccessor, IOptions<TenantsConfiguration> configuration)
        {
            var tenant = tenantAccessor.Tenant;
            var tenantsConfiguration = configuration.Value;
            string? connectionString = null;

            if (tenant == null || !tenantsConfiguration.ConnectionStrings.TryGetValue(tenant.Name, out connectionString))
            {
                throw new NullReferenceException($"The connection string was null for the tenant: {tenant?.DisplayName}");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            return optionsBuilder.UseNpgsql(connectionString).Options;
        }
    }
}
