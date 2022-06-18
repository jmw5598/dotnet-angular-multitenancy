using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using Xyz.Core.Interfaces.Multitenancy;
using Xyz.Core.Models;
using Xyz.Multitenancy.Data;

namespace Xyz.Infrastructure.Services.Multitenancy
{
    public class CompaniesService : ICompaniesService
    {
        private readonly ILogger<CompaniesService> _logger;
        private readonly MultitenancyDbContext _multitenancyDbContext;
        
        public CompaniesService(ILogger<CompaniesService> logger, MultitenancyDbContext multitenancyDbContext)
        {
            this._logger = logger;
            this._multitenancyDbContext = multitenancyDbContext;
        }

        public async Task<ValidationResult> DoesCompanyNameExistAsync(string companyName)
        {
            try
            {
                var company = await this._multitenancyDbContext.Companies
                    .Where(company => company.Name.Trim().ToLower() == companyName.Trim().ToLower())
                    .FirstOrDefaultAsync();

                return new ValidationResult
                {
                    IsValid = company == null
                };
            }
            catch (Exception ex)
            {
                var errorMessage = "Error checking if company exists!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                throw;
            }
        }
    }
}