import { createSelector } from "@ngrx/store";

import * as fromAdministration from '../../../../store';
import * as fromAccountDetails from './account-details.reducer';

export const selectAccountDetailsState = createSelector(
  fromAdministration.selectAdministrationState,
  (state: fromAdministration.AdministrationState) => state.accountDetails 
);

export const selectTenantStatistics = createSelector(
  selectAccountDetailsState,
  (state: fromAccountDetails.AccountDetailsState) => state.tenantStatistics
);
