using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using System.Data;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Interfaces;
using Xyz.Multitenancy.Data;

namespace Xyz.Infrastructure.Services
{
    public class PlansService : IPlansService
    {
        private readonly ILogger<PlansService> _logger;
        private readonly AuthenticationDbContext _context;

        public PlansService(ILogger<PlansService> logger, AuthenticationDbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<IEnumerable<Plan>> FindAll()
        {
            return await this._context.Plans.Select(p => p).ToListAsync();
        }
    }
}
