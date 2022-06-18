import { BaseMultitenancyEntity } from "./base-multitenancy.entity";
import { Tenant } from "./tenant.entity";

export interface BillingInvoice extends BaseMultitenancyEntity {
  transactionDate: Date,
  amount: number,
  status: string,
  tenantId: string,
  tenant?: Tenant
}
