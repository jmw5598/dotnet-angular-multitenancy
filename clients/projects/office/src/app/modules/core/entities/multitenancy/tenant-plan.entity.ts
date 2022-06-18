import { Plan } from './plan.entity';

export interface TenantPlan {
  id: string,
  renewalRate: string,
  maxUserCount: number,
  price: number,
  planId: string,
  plan?: Plan
}
