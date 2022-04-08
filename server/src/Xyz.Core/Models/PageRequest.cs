namespace Xyz.Core.Models
{
    public class PageRequest
    {
        public int Index { get; set; }
        public int Size { get; set; }
        public Sort Sort { get; set; } = default!;
    }
}
