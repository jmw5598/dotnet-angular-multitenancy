namespace Xyz.Core.Models.Configuration
{
    public class StripeSettings
    {
        public string PublishableKey { get; set; } = default!;
        public string SecretKey { get; set; } = default!;
    }
}
