using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

using Xyz.Core.Models;
using Xyz.Core.Models.Multitenancy;

namespace Xyz.Core.Entities.Multitenancy
{
    [Index(nameof(ExternalInvoiceId), IsUnique = true)]
    public class BillingInvoice : BaseEntity
    {
        public DateTime TransactionDate { get; set; } = default!;
        public DateTime PeriodStartDate { get; set; } = default!;
        public DateTime PeriodEndDate { get; set; } = default!;
        public DateTime PaidDate { get; set; } = default!;
        public decimal AmountPaid { get; set; } = default!;
        public decimal AmountDue { get; set; } = default!;
        
        [Column(TypeName = "varchar(24)")]
        public BillingInvoiceStatus Status { get; set; } = default!;

        public string? BillingReason { get; set; } = default!;
        public string? InvoiceUrl { get; set; } = default!;
        public string? InvoicePdfUrl { get; set; } = default!;

        [Column(TypeName = "varchar(256)")]
        public string ExternalInvoiceId { get; set; } = default!;

        public Guid TenantId { get; set; } = default!;
        public virtual Tenant Tenant { get; set; } = default!;

        public BillingInvoiceDto ToDto()
        {
            return new BillingInvoiceDto
            {
                Id = this.Id,
                TransactionDate = this.TransactionDate,
                PeriodStartDate = this.PeriodStartDate,
                PeriodEndDate = this.PeriodEndDate,
                PaidDate = this.PaidDate,
                AmountPaid = this.AmountPaid,
                AmountDue = this.AmountDue,
                Status = this.Status,
                BillingReason = this.BillingReason,
                InvoiceUrl = this.InvoiceUrl,
                InvoicePdfUrl = this.InvoicePdfUrl,
                ExternalInvoiceId = this.ExternalInvoiceId,
                TenantId = this.TenantId 
            };
        }
    }
}
