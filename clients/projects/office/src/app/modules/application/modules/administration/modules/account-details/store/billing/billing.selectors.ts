import { createSelector } from '@ngrx/store';

import * as fromAdministration from '../../../../store';
import * as fromBilling from './billing.reducer';

export const selectBillingState = createSelector(
  fromAdministration.selectAdministrationState,
  (state: fromAdministration.AdministrationState) => state.billing 
);

export const selectBillingInvoicesPage = createSelector(
  selectBillingState,
  (state: fromBilling.BillingState) => state.billingInvoicesPage
);

export const selectBillingInvoicesSearchFilter = createSelector(
  selectBillingState,
  (state: fromBilling.BillingState) => state.billingInvoicesSearchFilter
);

export const selectBillingInvoicesTableDefinition = createSelector(
  selectBillingState,
  (state: fromBilling.BillingState) => state.billingInvoicesTableDefinition
);
