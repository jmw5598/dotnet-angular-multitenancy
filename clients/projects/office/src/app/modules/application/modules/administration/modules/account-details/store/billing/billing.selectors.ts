import { createSelector } from "@ngrx/store";

import * as fromAdministration from '../../../../store';
import * as fromUserAccounts from './billing.reducer';

export const selectBillingState = createSelector(
  fromAdministration.selectAdministrationState,
  (state: fromAdministration.AdministrationState) => state.billing 
);
