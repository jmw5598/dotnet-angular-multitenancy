namespace Xyz.Core.Entities.Tenant
{
    public class Vehicle
    {
        public Guid Id { get; set; } = default!;
        public string Vin { get; set; } = default!;
        public VehicleMake Make { get; set; } = default!;
        public VehicleModel Model { get; set; } = default!;
        public VehicleType Type { get; set; } = default!;
    }
}
