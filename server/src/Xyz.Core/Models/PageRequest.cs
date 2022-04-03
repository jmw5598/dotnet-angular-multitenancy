namespace Xyz.Core.Models
{
    public class PageRequest
    {
        public long Index { get; set; }
        public long Size { get; set; }
        public Sort Sort { get; set; } = default!;
    }
}
