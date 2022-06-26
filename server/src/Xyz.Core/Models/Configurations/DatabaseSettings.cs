namespace Xyz.Core.Models.Configuration
{
    public class DatabaseSettings
    {
        public string Server { get; set; } = default!;
        public int Port { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Database { get; set; } = default!;
    }
}
