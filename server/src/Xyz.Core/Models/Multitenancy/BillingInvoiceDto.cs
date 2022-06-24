namespace Xyz.Core.Models.Multitenancy
{
    public class BillingInvoiceDto 
    {
        public Guid Id { get; set; } = default!;
        public DateTime TransactionDate { get; set; } = default!;
        public DateTime PeriodStartDate { get; set; } = default!;
        public DateTime PeriodEndDate { get; set; } = default!;
        public DateTime PaidDate { get; set; } = default!;
        public decimal AmountPaid { get; set; } = default!;
        public decimal AmountDue { get; set; } = default!;
        public BillingInvoiceStatus Status { get; set; } = default!;
        public string? BillingReason { get; set; } = default!;
        public string? InvoiceUrl { get; set; } = default!;
        public string? InvoicePdfUrl { get; set; } = default!;
        public string ExternalInvoiceId { get; set; } = default!;
        public Guid TenantId { get; set; } = default!;
        
    }
}