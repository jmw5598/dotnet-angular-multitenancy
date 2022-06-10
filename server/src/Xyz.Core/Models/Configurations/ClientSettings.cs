namespace Xyz.Core.Models.Configuration
{
    public class ClientSettings
    {
        public string Protocol { get; set; } = default!;
        public string Host { get; set; } = default!;
        public int Port { get; set; } = default!;
    }
}