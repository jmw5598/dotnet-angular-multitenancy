namespace Xyz.Core.Models.Multitenancy.Payments
{
    public class CreateCustomerResponse
    {
        public string CustomerId { get; set; } = default!;
        public string DefaultSourceId { get; set; } = default!;
    }
}
