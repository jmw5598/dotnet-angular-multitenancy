import { Sort, SortDirection } from "@xyz/office/modules/core/models";

export const defaultUserAccountsSort: Sort = {
  column: 'userName',
  direction: SortDirection.Ascend
} as Sort;
