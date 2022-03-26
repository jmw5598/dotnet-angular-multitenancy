import { createFeatureSelector, createSelector } from "@ngrx/store";
import * as fromPlans from './plans.reducer';

export const selectPlansState = createFeatureSelector<fromPlans.PlansState>(
  fromPlans.plansFeatureKey
);

export const selectAuthenticatedUser = createSelector(
  selectPlansState,
  (state: fromPlans.PlansState) => state.availablePlans
);
