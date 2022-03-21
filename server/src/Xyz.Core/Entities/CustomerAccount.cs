namespace Xyz.Core.Entities
{
    public class CustomerAccount
    {
        public string Id { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
