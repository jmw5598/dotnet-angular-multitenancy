import { Sort, SortDirection } from '@xyz/office/modules/core/models';

export const defaultSecurityPermissionsSort: Sort  = {
  column: 'name',
  direction: SortDirection.Ascend
} as Sort;
