using Microsoft.Extensions.Logging;

using Xyz.Infrastructure.Data;
using Xyz.Core.Interfaces;

namespace Xyz.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UsersService> _logger;
        private readonly ApplicationDbContext _context;

        public UserService(ILogger<UsersService> logger, ApplicationDbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<object> GetUserSettings(string userId)
        {
            return new {}; // @TODO
        }

        public async Task<object> GetUserPermissions(string userId)
        {
            return new {}; // @TODO
        }
    }
}