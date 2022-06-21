using Xyz.Core.Models.Multitenancy;

namespace Xyz.Core.Dtos.Multitenancy
{
    public class PlanDto
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public bool PaymentRequired { get; set; } = true!;
        public SubscriptionRenewalRate RenewalRate { get; set; } = default!;
        public int MaxUserCount { get; set; }
        public string? ExternalPlanId { get; set; } = default!;
    }
}
