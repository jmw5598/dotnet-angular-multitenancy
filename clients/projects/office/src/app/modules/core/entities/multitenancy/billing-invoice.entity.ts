import { BaseMultitenancyEntity } from './base-multitenancy.entity';
import { Tenant } from './tenant.entity';

export interface BillingInvoice extends BaseMultitenancyEntity {
  transactionDate: Date,
  periodStartDate: Date,
  periodEndDate: Date,
  paidDate: Date,
  amountPaid: number,
  amountDue: number,
  status: string,
  billingReason: string,
  invoiceUrl: string,
  invoicePdfUrl: string,
  externalInvoiceId: string,
  tenantId: string,
  tenant?: Tenant
}
