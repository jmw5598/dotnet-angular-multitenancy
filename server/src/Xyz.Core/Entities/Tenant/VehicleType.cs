using System.ComponentModel.DataAnnotations;

namespace Xyz.Core.Entities.Tenant
{
    public class VehicleType
    {
        [Key]
        public Guid Id { get; set; } = default!;
    }
}
