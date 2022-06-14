namespace Xyz.Core.Models.SearchFilters
{
    public class DateRangeQuerySearchFilter : BasicQuerySearchFilter
    {
        public DateTime? StartDate { get; set; } = default!;
        public DateTime? EndDate { get; set; } = default!;
    }
}