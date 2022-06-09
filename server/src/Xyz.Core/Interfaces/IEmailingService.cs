using Xyz.Core.Models;

namespace Xyz.Core.Interfaces
{
    public interface IEmailingService
    {
        public Task<bool> SendEmailAsync(EmailRequest request);
    }
}
