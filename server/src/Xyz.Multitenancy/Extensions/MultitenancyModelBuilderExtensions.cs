using Microsoft.EntityFrameworkCore;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Models;

namespace Xyz.Multitenancy.Extensions
{
    public static class MultitenancyModelBuilderExtensions
    {
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