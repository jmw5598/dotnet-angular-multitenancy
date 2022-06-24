namespace Xyz.Core.Models.Multitenancy.Payments
{
    public class CreateSubscriptionRequest
    {
        public string CustomerId { get; set; } = default!;
        public string ExternalPlanId { get; set; } = default!;
    }
}
