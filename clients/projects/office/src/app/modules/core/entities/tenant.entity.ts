import { Company } from "./company.entity"

export interface Tenant {
  id: string,
  name: string,
  displayName: string
  companyId: string,
  tenantPlanId: string
  company?: Company
}
