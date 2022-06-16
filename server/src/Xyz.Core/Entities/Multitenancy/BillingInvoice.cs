using System.ComponentModel.DataAnnotations.Schema;

using Xyz.Core.Models;
using Xyz.Core.Models.Multitenancy;

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

        public BillingInvoiceDto ToDto()
        {
            return new BillingInvoiceDto
            {
                Id = this.Id,
                TransactionDate = this.TransactionDate,
                Amount = this.Amount,
                Status = this.Status,
                TenantId = this.TenantId
            };
        }
    }
}
