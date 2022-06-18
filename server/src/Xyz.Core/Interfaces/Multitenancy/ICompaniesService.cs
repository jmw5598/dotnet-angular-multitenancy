using Xyz.Core.Models;

namespace Xyz.Core.Interfaces.Multitenancy
{
    public interface ICompaniesService 
    {
        Task<ValidationResult> DoesCompanyNameExistAsync(string companyName);
    }
}
