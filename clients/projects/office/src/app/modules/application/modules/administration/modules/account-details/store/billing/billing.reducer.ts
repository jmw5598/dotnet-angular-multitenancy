import { createReducer, on } from '@ngrx/store';
import { defaultDateRangeQuerySearchFilter } from '@xyz/office/modules/core/constants';
import { BillingInvoice } from '@xyz/office/modules/core/entities';
import { Page } from '@xyz/office/modules/core/models';
import { DateRangeQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

import * as fromBilling from './billing.actions';

export const billingFeatureKey = 'billing';

export interface BillingState {
  billingInvoicesPage: Page<BillingInvoice> | null,
  billingInvoicesSearchFilter: DateRangeQuerySearchFilter | null,
}

export const initialBillingState: BillingState = {
  billingInvoicesPage: null,
  billingInvoicesSearchFilter: defaultDateRangeQuerySearchFilter()
}

export const reducer = createReducer(
  initialBillingState
);
