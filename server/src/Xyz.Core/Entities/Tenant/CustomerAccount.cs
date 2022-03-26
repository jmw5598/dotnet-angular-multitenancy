namespace Xyz.Core.Entities.Tenant
{
    public class CustomerAccount
    {
        public Guid Id { get; set; } = default!;
        public Customer Customer { get; set; } = default!;
        public ICollection<Vehicle> Vehicles { get; set; } = default!;
    }
}
