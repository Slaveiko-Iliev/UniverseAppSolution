
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UniverseUser>> GetActiveUsersAsync();
        Task<IEnumerable<UniverseUser>> GetUnactiveUsersAsync();
    }
}
