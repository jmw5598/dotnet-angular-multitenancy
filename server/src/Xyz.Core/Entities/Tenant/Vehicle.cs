namespace Xyz.Core.Entities.Tenant
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string Vin { get; set; }
        public VehicleMake Make { get; set; }
        public VehicleModel Model { get; set; }
        public VehicleType Type { get; set; }
    }
}
