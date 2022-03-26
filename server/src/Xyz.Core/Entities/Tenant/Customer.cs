namespace Xyz.Core.Entities.Tenant
{
    public class Customer
    {
        public Guid Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
