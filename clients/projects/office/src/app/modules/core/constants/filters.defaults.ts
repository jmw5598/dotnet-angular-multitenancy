import { BasicQuerySearchFilter, DateRangeQuerySearchFilter } from '../../shared/modules/query-search-filter';

export const defaultBasicQuerySearchFilter: BasicQuerySearchFilter = {
  query: ''
} as BasicQuerySearchFilter;

export const defaultDateRangeQuerySearchFilter: DateRangeQuerySearchFilter = {
  query: '',
  startDate: null,
  endDate: null
} as DateRangeQuerySearchFilter;
