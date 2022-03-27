namespace Xyz.Core.Models
{
    public class ResponseMessage
    {
        public ResponseStatus Status { get; set; } = default!;
        public string Message { get; set; } = default!;
    }
}
