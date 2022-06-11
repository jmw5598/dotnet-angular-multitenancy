using Xyz.Core.Models;

namespace Xyz.Core.Interfaces
{
    public interface ICompaniesService 
    {
        Task<ValidationResult> DoesCompanyNameExistAsync(string companyName);
    }
}
