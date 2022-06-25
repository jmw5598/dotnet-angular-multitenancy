import { createReducer, on } from '@ngrx/store';
import { defaultDateRangeQuerySearchFilter } from '@xyz/office/modules/core/constants';
import { BillingInvoice } from '@xyz/office/modules/core/entities/multitenancy';
import { Page } from '@xyz/office/modules/core/models';
import { TableDefinition } from '@xyz/office/modules/shared/modules/datatable';
import { DateRangeQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';
import { getDefaultBillingInvoicesTableDefinition } from '../../pages/billing/billing-invoices-table-definition.defaults';

import * as fromBilling from './billing.actions';

export const billingFeatureKey = 'billing';

export interface BillingState {
  billingInvoicesPage: Page<BillingInvoice> | null,
  billingInvoicesSearchFilter: DateRangeQuerySearchFilter | null,
  billingInvoicesTableDefinition: TableDefinition | null,
}

export const initialBillingState: BillingState = {
  billingInvoicesPage: null,
  billingInvoicesSearchFilter: defaultDateRangeQuerySearchFilter,
  billingInvoicesTableDefinition: getDefaultBillingInvoicesTableDefinition()
}

const handleSearchBillingInvoicesRequestSuccess = (state: BillingState, { page }: any) => ({
  ...state,
  billingInvoicesPage: page
} as BillingState);

const handleSetBillingInvoicesSearchFilter = (state: BillingState, { filter }: any) => ({
  ...state,
  billingInvoicesSearchFilter: filter
} as BillingState);

const handleSetBillingInvoicesTableDefinition = (state: BillingState, { tableDefinition }: any) => ({
  ...state,
  billingInvoicesTableDefinition: tableDefinition
} as BillingState);

const handleResetBillingInvoicesTableDefinition = (state: BillingState) => ({
  ...state,
  billingInvoicesTableDefinition: getDefaultBillingInvoicesTableDefinition()
} as BillingState);

export const reducer = createReducer(
  initialBillingState,
  on(
    fromBilling.searchBillingInvoicesRequestSuccess,
    handleSearchBillingInvoicesRequestSuccess
  ),
  on(
    fromBilling.setBillingInvoicesSearchFilter,
    handleSetBillingInvoicesSearchFilter
  ),
  on(
    fromBilling.setBillingInvoicesTableDefinition,
    handleSetBillingInvoicesTableDefinition
  ),
  on(
    fromBilling.resetBillingInvoicesTableDefinition,
    handleResetBillingInvoicesTableDefinition
  )
);
