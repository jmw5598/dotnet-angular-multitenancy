import { createReducer, on } from '@ngrx/store';

import { Plan } from '@xyz/office/modules/core/entities';
import * as fromPlans from './plans.actions';

export const plansFeatureKey = 'plans';

export interface PlansState {
  availablePlans: Plan[] | null
}

export const initialPlansState: PlansState = {
  availablePlans: null
}

const handleGetPlansRequestSuccess = (state: PlansState, { plans }: any) => ({
  ...state,
  availablePlans: plans
} as PlansState);

export const reducer = createReducer(
  initialPlansState,
  on(fromPlans.getPlansRequestSuccess, handleGetPlansRequestSuccess)
);
