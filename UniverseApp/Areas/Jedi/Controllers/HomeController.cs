using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Areas.Jedi.Controllers
{
    public class HomeController : JediBaseController
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllUsers()
        {
            var users = new List<UniverseUser>();

            var activeUsers = await _userService.GetActiveUsersAsync();
            var unactiveUsers = await _userService.GetUnactiveUsersAsync();

            users.AddRange(activeUsers);
            users.AddRange(unactiveUsers);

            return View(users);
        }
    }
}
