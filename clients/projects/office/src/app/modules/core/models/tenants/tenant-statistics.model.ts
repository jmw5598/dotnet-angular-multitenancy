import { Tenant } from "../../entities";

export interface TenantStatistics {
  tenant: Tenant,
  userAccountsCount: number,
  lastInvoiceDate: Date,
  nextInvoiceDate: Date
}
