using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository _repository;
		private readonly UserManager<UniverseUser> _userManager;

		public UserService(IRepository repository, UserManager<UniverseUser> userManager)
		{
			_repository = repository;
			_userManager = userManager;
		}

		public async Task ChangeUserActivityAsync(string userId)
		{
			var users = _repository.All<UniverseUser>();

			if (await users.AnyAsync(u => u.Id == userId))
			{
				var user = users.First(u => u.Id == userId);
				user.IsActive = !user.IsActive;

				await _repository.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<UniverseUser>> GetUsersAsync() =>
			await _repository.AllReadOnly<UniverseUser>()
			.OrderByDescending(u => u.IsActive)
			.ToListAsync();

		public async Task<bool> IsUserActive(string userId) =>
			await _userManager.Users
			.Where(u => u.Id == userId)
			.AnyAsync(u => u.IsActive);
	}
}
