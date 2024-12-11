using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UniverseApp.Areas.Jedi.Models;
using UniverseApp.Core.Services.Contracts;

namespace UniverseApp.Areas.Jedi.Controllers
{


	public class UserController : JediBaseController
	{
		private readonly IUserService _userService;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UserController(IUserService userService, RoleManager<IdentityRole> roleManager)
		{
			_userService = userService;
			_roleManager = roleManager;
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
					IsPadawan = User.IsPadawan(_roleManager)
				})
			};

			return View(model);
		}

		public async Task<IActionResult> ChangeActivity(string id)
		{
			await _userService.ChangeUserActivityAsync(id);

			return RedirectToAction(nameof(AllUsers), "User", new { area = "Jedi" });
		}
	}
}
