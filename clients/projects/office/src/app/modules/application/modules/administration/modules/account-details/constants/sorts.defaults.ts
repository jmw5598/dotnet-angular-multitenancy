import { Sort, SortDirection } from "@xyz/office/modules/core/models";

export const defaultBillingInvoicesSort: Sort = {
  column: 'transactionDate',
  direction: SortDirection.Descend
};
