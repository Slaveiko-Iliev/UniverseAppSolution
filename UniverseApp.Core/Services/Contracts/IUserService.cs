
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services.Contracts
{
	public interface IUserService
	{
		Task ChangeUserPadawanStatusAsync(string userId);
		Task ChangeUserActivityAsync(string userId);
		Task<IEnumerable<UniverseUser>> GetUsersAsync();
		public Task<bool> IsUserActiveAsync(string userId);

	}
}
