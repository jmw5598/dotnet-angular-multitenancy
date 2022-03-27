using Xyz.Core.Models;

namespace Xyz.Core.Interfaces
{
    public interface IUsersService
    {
        Task<ValidationResult> VerifyEmail(string email);
        Task<ValidationResult> VerifyUserName(string userName);
    }
}
