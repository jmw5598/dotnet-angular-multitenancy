import { Company } from './company.entity'
import { TenantPlan } from './tenant-plan.entity'

export interface Tenant {
  id: string,
  name: string,
  displayName: string
  isActive: boolean,
  companyId: string,
  tenantPlanId: string
  tenantPlan?: TenantPlan,
  company?: Company
}
