import { createReducer, on } from '@ngrx/store';

import * as fromBilling from './billing.actions';

export const billingFeatureKey = 'billing';

export interface BillingState {
}

export const initialBillingState: BillingState = {
}

export const reducer = createReducer(
  initialBillingState
);
