using Xyz.Core.Models.Multitenancy;

namespace Xyz.Core.Dtos.Multitenancy
{
    public class TenantPlanDto
    {
        public Guid Id { get; set; } = default!;
        public SubscriptionRenewalRate RenewalRate { get; set; } = default!;
        public int MaxUserCount { get; set; }
        public decimal Price { get; set; }
        public PlanDto? Plan { get; set; } = default!;
    }
}
