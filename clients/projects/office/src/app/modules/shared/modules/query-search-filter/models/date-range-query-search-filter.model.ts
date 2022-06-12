import { BasicQuerySearchFilter } from "./basic-query-search-filter.model";

export interface DateRangeQuerySearchFilter extends BasicQuerySearchFilter {
  startDate: Date | null,
  endDate: Date | null
}
