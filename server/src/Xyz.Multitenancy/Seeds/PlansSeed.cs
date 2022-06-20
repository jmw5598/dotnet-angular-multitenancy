using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Models.Multitenancy;

namespace Xyz.Multitenancy.Seeds
{
    public static class PlansSeed
    {
        public static ICollection<Plan> Get()
        {
            return new List<Plan> {
                new Plan {
                    Id = new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"),
                    Name = "Free",
                    Price = 0.00M,
                    PaymentRequired = false,
                    RenewalRate = SubscriptionRenewalRate.MONTHLY,
                    MaxUserCount = 2
                },
                new Plan {
                    Id = new Guid("81048da5-948f-4304-a5b2-908ac1ee44b8"),
                    Name = "Basic",
                    Price = 10.00M,
                    PaymentRequired = true,
                    RenewalRate = SubscriptionRenewalRate.MONTHLY,
                    MaxUserCount = 5
                },
                new Plan {
                    Id = new Guid("81048da5-948f-4304-a5b2-908ac1ee44b9"),
                    Name = "Pro",
                    Price = 100.00M,
                    PaymentRequired = true,
                    RenewalRate = SubscriptionRenewalRate.MONTHLY,
                    MaxUserCount = 100
                }
            };
        }
    }
}