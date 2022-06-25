import { createAction, props } from '@ngrx/store';

import { BillingInvoice } from '@xyz/office/modules/core/entities/multitenancy';
import { Page, PageRequest, ResponseMessage } from '@xyz/office/modules/core/models';
import { TableDefinition } from '@xyz/office/modules/shared/modules/datatable';
import { DateRangeQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

export const getBillingDetails = createAction(
  '[Billing] Get Billing Details Request',
);

export const searchBillingInvoicesRequest = createAction(
  '[Billing] Search Billing Invoices Request',
  props<{ filter: DateRangeQuerySearchFilter, pageRequest: PageRequest }>()
);

export const searchBillingInvoicesRequestSuccess = createAction(
  '[Billing] Search Billing Invoices Request Success',
  props<{ page: Page<BillingInvoice> }>()
);

export const searchBillingInvoicesRequestFailure = createAction(
  '[Billing] Search Billing Invoices Request Failure',
  props<{ message: ResponseMessage }>()
);

export const setBillingInvoicesSearchFilter = createAction(
  '[Billing] Set Billing Invoices Search Filter',
  props<{ filter: DateRangeQuerySearchFilter | null }>()
);

export const setBillingInvoicesTableDefinition = createAction(
  '[Billing] Set Billing Invoices Table Definition',
  props<{ tableDefinition: TableDefinition | null }>()
);

export const resetBillingInvoicesTableDefinition = createAction(
  '[Billing] Reset Billing Invoices Table Definition'
);
