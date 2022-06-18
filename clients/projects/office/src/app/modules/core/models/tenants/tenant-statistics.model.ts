import { Tenant } from '@xyz/office/modules/core/entities/multitenancy';

export interface TenantStatistics {
  tenant: Tenant,
  userAccountsCount: number,
  lastInvoiceDate: Date,
  nextInvoiceDate: Date
}
