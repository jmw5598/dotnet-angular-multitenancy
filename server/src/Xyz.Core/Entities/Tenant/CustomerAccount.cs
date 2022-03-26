namespace Xyz.Core.Entities.Tenant
{
    public class CustomerAccount
    {
        public string Id { get; set; } = default!;
        public Customer Customer { get; set; } = default!;
        public ICollection<Vehicle> Vehicles { get; set; } = default!;
    }
}
