using Xyz.Core.Models.Tenants;

namespace Xyz.Core.Interfaces.Tenants
{
    public interface IEmailingService
    {
        public Task<bool> SendEmailAsync(EmailRequest request);
    }
}
