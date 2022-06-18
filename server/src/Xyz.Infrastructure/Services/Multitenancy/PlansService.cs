using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using System.Data;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Interfaces.Multitenancy;
using Xyz.Multitenancy.Data;

namespace Xyz.Infrastructure.Services.Multitenancy
{
    public class PlansService : IPlansService
    {
        private readonly ILogger<PlansService> _logger;
        private readonly MultitenancyDbContext _context;

        public PlansService(ILogger<PlansService> logger, MultitenancyDbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<IEnumerable<Plan>> FindAllAsync()
        {
            return await this._context.Plans.Select(p => p).ToListAsync();
        }
    }
}
