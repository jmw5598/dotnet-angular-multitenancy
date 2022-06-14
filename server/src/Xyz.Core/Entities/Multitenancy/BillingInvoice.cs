using System.ComponentModel.DataAnnotations.Schema;

using Xyz.Core.Models;

namespace Xyz.Core.Entities.Multitenancy
{
    public class BillingInvoice : BaseEntity
    {
        public DateTime TransactionDate { get; set; } = default!;
        public decimal Amount { get; set; } = default!;
        
        [Column(TypeName = "varchar(24)")]
        public TransactionStatus Status { get; set; } = default!;

        public Guid TenantId { get; set; } = default!;
        public virtual Tenant Tenant { get; set; } = default!;
    }
}
