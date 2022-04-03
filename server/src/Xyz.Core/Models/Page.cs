namespace Xyz.Core.Models
{
    public class Page<T>
    {
        public ICollection<T> Elements { get; set; } = default!;
        public long TotalElements { get; set; }
        public long TotalPage { get; set; }
        public PageRequest Current { get; set; } = default!;
        public PageRequest Next { get; set; } = default!;
        public PageRequest Previous { get; set; } = default!;
    }
}
