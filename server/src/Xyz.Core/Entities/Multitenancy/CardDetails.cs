namespace Xyz.Core.Entities.Multitenancy
{
    public class CardDetails : BaseEntity
    {
        public bool IsValid { get; set; } = false!;
        public string Brand { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
