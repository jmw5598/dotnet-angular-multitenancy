namespace Xyz.Core.Models
{
    public class EmailRequest
    {
        public string To { get; set; } = default!;
        public string? From { get; set; } = null!;
        public string Subject { get; set; } = default!;
        public string Body { get; set; } = default!;
    }
}
