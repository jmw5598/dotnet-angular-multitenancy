using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Xyz.Multitenancy.Models;
using Xyz.Multitenancy.Multitenancy;
using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Tenant;
using Xyz.Core.Entities.Identity;
using Xyz.Infrastructure.Extensions;

namespace Xyz.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<
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
        private readonly ITenantAccessor<Tenant> _tenantAccessor;
        private readonly IOptions<TenantsConfiguration> _configuration;
        

        // Identity Datasets
        public DbSet<Profile> Profiles => Set<Profile>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();


        // Entity Datasets
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<VehicleMake> VehicleMakes => Set<VehicleMake>();
        public DbSet<VehicleModel> VehicleModels => Set<VehicleModel>();
        public DbSet<VehicleType> VehicleTypes => Set<VehicleType>();

        public DbSet<ModulePermission> ModulePermissions => Set<ModulePermission>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<UserModulePermission> UserModulePermissions => Set<UserModulePermission>();
        public DbSet<UserPermission> UserPermissions => Set<UserPermission>();
        
        public DbSet<TemplateModulePermission> TemplateModulePermissions => Set<TemplateModulePermission>();
        public DbSet<TemplateModulePermissionName> TemplateModulePermissionNames => Set<TemplateModulePermissionName>();
        public DbSet<TemplatePermission> TemplatePermissions => Set<TemplatePermission>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<TenantsConfiguration> configuration,
            ITenantAccessor<Tenant> tenantAccessor) : base(CreateDbContextOptions(tenantAccessor, configuration))
        {

            this._tenantAccessor = tenantAccessor;
            this._configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HandleCustomIdentityTableMapping();
            modelBuilder.SeedRoles();
            modelBuilder.SeedPermissions();
        }
        

        private static DbContextOptions CreateDbContextOptions(ITenantAccessor<Tenant> tenantAccessor, IOptions<TenantsConfiguration> configuration)
        {
            var tenant = tenantAccessor.Tenant;
            var tenantsConfiguration = configuration.Value;
            string? connectionString = tenant?.ConnectionString;

            // @TODO use connection string form db

            if (tenant == null || connectionString == null)
            {
                throw new NullReferenceException($"The connection string was null for the tenant: {tenant?.DisplayName}");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            return optionsBuilder
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention()
                .Options;
        }

        /// <summary>
        /// Taken from here: https://medium.com/oppr/net-core-using-entity-framework-core-in-a-separate-project-e8636f9dc9e5
        /// </summary>
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Xyz.Infrastructure/config.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                var connectionString = configuration.GetConnectionString("DevCompany");
                builder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
                return new ApplicationDbContext(builder.Options);
            }
        }
    }
}
