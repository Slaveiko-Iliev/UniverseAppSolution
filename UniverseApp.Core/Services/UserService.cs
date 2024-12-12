using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Constants;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository _repository;
		private readonly UserManager<UniverseUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UserService(IRepository repository, UserManager<UniverseUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_repository = repository;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task ChangeUserPadawanStatusAsync(string userId)
		{
			var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
			var padawanRole = await _roleManager.FindByNameAsync(JediConstants.PadawanRoleName);

			if (user == null || padawanRole == null)
			{
				throw new InvalidOperationException("User or Padawan role not found.");
			}

			if (!await _userManager.IsInRoleAsync(user, JediConstants.PadawanRoleName))
			{
				await _userManager.AddToRoleAsync(user, JediConstants.PadawanRoleName);
			}
			else
			{
				await _userManager.RemoveFromRoleAsync(user, JediConstants.PadawanRoleName);
			}
		}

		public async Task ChangeUserActivityAsync(string userId)
		{
			var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

			if (user != null)
			{
				user.IsActive = !user.IsActive;

				await _repository.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<UniverseUser>> GetUsersAsync() =>
			await _repository.AllReadOnly<UniverseUser>()
			.OrderByDescending(u => u.IsActive)
			.ToListAsync();

		public async Task<bool> IsUserActiveAsync(string userId) =>
			await _userManager.Users
			.Where(u => u.Id == userId)
			.AnyAsync(u => u.IsActive);
	}
}
