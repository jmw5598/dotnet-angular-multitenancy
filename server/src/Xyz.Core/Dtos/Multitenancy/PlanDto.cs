using Xyz.Core.Models;

namespace Xyz.Core.Dtos
{
    public class PlanDto
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public SubscriptionRenewalRate RenewalRate { get; set; } = default!;
        public int MaxUserCount { get; set; }
    }
}
