using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using Xyz.Core.Entities;

namespace Xyz.Multitenancy.Data
{
    public class AuthenticationDbContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }

        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
             .HasMany(x => x.Tenants)
             .WithMany(x => x.Users)
             .UsingEntity<Dictionary<string, object>>("UserTenants",
                 x => x.HasOne<Tenant>().WithMany().HasForeignKey("TenantId"),
                 x => x.HasOne<ApplicationUser>().WithMany().HasForeignKey("AspNetUserId"),
                 x => x.ToTable("UserTenants"));
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
                builder.UseNpgsql(connectionString);

                return new AuthenticationDbContext(builder.Options);
            }
        }
    }
}
