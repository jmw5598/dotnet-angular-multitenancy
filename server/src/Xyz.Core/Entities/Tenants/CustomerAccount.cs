namespace Xyz.Core.Entities.Tenants
{
    public class CustomerAccount : BaseEntity
    {
        public Customer Customer { get; set; } = default!;
        public ICollection<Vehicle> Vehicles { get; set; } = default!;
    }
}
