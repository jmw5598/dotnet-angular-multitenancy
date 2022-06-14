using Microsoft.EntityFrameworkCore;

namespace Xyz.Core.Models.Paging
{
    public class Page<T>
    {
        public ICollection<T> Elements { get; set; } = default!;
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
        public PageRequest Current { get; set; } = default!;
        public PageRequest Next { get; set; } = default!;
        public PageRequest Previous { get; set; } = default!;

        public static async Task<Page<T>> From(IQueryable<T> source, PageRequest pageRequest)
        {
            var count = await source.CountAsync();
            var elements = await source
                    .Skip(pageRequest.Index * pageRequest.Size)
                    .Take(pageRequest.Size)
                    .ToListAsync();

            var totalPages = (int) Math.Ceiling(count / (double) pageRequest.Size);

            return new Page<T>
            {
                TotalElements = count,
                TotalPages = totalPages,
                Elements = elements,
                Current = pageRequest
            };
        }
    }
}
