
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services.Contracts
{
	public interface IUserService
	{
		Task ChangeUserActivityAsync(string userId);
		Task<IEnumerable<UniverseUser>> GetUsersAsync();
		public Task<bool> IsUserActive(string userId);

	}
}
