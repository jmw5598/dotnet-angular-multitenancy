namespace Xyz.Core.Models.Multitenancy
{
    public class BillingInvoiceDto 
    {
        public Guid Id { get; set; } = default!;
        public DateTime TransactionDate { get; set; } = default!;
        public decimal Amount { get; set; } = default!;
        public TransactionStatus Status { get; set; } = default!;
        public Guid TenantId { get; set; } = default!;
        public string ExternalTransactionId { get; set; } = default!;
    }
}