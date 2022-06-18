using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

using Xyz.Core.Interfaces.Tenants;
using Xyz.Core.Models.Tenants;
using Xyz.Core.Models.Configuration;

namespace Xyz.Infrastructure.Services.Tenants
{
    public class EmailingService : IEmailingService
    {
        private readonly ILogger<EmailingService> _logger;
        private readonly IOptions<SmtpSettings> _smtpSettings;

        public EmailingService(IOptions<SmtpSettings> smtpSettings, ILogger<EmailingService> logger)
        {
            this._smtpSettings = smtpSettings;
            this._logger = logger;
        }

        public async Task<bool> SendEmailAsync(EmailRequest request)
        {
            var smtpSettings = this._smtpSettings.Value;
             // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(request.From ?? smtpSettings.FromEmail));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            // send email
            using var smtp = new SmtpClient();
            try {
                smtp.Connect(smtpSettings.Host, smtpSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(smtpSettings.User, smtpSettings.Password);
                var response = smtp.Send(email);

                if (!response.Trim().ToLower().StartsWith("ok"))
                {
                    throw new Exception("Error sending email", new Exception(response));
                }

                smtp.Disconnect(true);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                smtp.Disconnect(true);
                var erroMessage = "Error sending email!";
                var logData = new { Exception = ex.Message, EmailRequest = request };
                this._logger.LogError(erroMessage, logData);
                return await Task.FromResult(false);
            }
        }
    }
}
