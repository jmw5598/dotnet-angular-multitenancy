namespace Xyz.Core.Models.Configuration
{
    public class TenantConnectionSettings
    {
        public string Server { get; set; } = default!;
        public int Port { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}