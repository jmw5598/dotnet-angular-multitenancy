import { BaseEntity } from "../base.entity";
import { Tenant } from "../tenant.entity";

export interface BillingInvoice extends BaseEntity {
  id: string,
  transactionDate: Date,
  amount: number,
  status: string,
  tenantId: string,
  tenant?: Tenant
}
