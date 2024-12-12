using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniverseApp.Areas.Jedi.Models;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Constants.JediConstants;

namespace UniverseApp.Areas.Jedi.Controllers
{


	public class UserController : JediBaseController
	{
		private readonly IUserService _userService;
		private readonly UserManager<UniverseUser> _userManager;

		public UserController(IUserService userService, UserManager<UniverseUser> userManager)
		{
			_userService = userService;
			_userManager = userManager;
		}

		public async Task<IActionResult> AllUsers()
		{
			var users = await _userService.GetUsersAsync();

			var model = new UserAllQueryModel()
			{
				TotalUsersCount = users.Count(),
				Users = users.Select(u => new UserAllViewModel()
				{
					Id = u.Id,
					FirstName = u.FirstName,
					LastName = u.LastName,
					IsActive = u.IsActive,
					IsPadawan = _userManager.IsInRoleAsync(u, PadawanRoleName).Result
				})
			};

			return View(model);
		}

		public async Task<IActionResult> ChangeActivity(string id)
		{
			await _userService.ChangeUserActivityAsync(id);

			return RedirectToAction(nameof(AllUsers), "User", new { area = "Jedi" });
		}

		public async Task<IActionResult> ManageUserPadawanRole(string id)
		{
			try
			{
				await _userService.ChangeUserPadawanStatusAsync(id);
			}
			catch (InvalidOperationException)
			{
				return BadRequest();
			}

			return RedirectToAction(nameof(AllUsers), "User", new { area = "Jedi" }); ;
		}
	}
}
