namespace Xyz.Core.Models.Configuration
{
    public class SmtpSettings
    {
        public string Host { get; set; } = default!;
        public int Port { get; set; } = default!;
        public string User { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FromEmail { get; set; } = default!; 
    }
}
