using System.ComponentModel.DataAnnotations.Schema;

using Xyz.Core.Models.Multitenancy;

namespace Xyz.Core.Entities.Multitenancy
{
    public class PaymentDetails : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Zip { get; set; } = default!;
        [Column(TypeName = "varchar(24)")]
        public PaymentProcessor PaymentProcessor { get; set; } = default!;
        public Guid CardDetailsId { get; set; } = default!;
        public virtual CardDetails CardDetails { get; set; } = default!;
    }
}
