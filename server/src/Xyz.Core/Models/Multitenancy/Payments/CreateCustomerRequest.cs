namespace Xyz.Core.Models.Multitenancy.Payments
{
    public class CreateCustomerRequest
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Zip { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Source { get; set; } = default!;
    }
}
