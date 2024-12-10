using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UniverseUser>> GetActiveUsersAsync() =>
            await _repository.AllReadOnly<UniverseUser>()
                .Where(u => u.IsActive)
                .ToListAsync();

        public async Task<IEnumerable<UniverseUser>> GetUnactiveUsersAsync() =>
            await _repository.AllReadOnly<UniverseUser>()
                .Where(u => !u.IsActive)
                .ToListAsync();
    }
}
