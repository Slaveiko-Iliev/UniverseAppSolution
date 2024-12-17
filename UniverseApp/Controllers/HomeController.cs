using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Services.Contracts;

namespace UniverseApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await _homeService.GetBriefMoviesInfoAsync();
            return View(model);
        }



        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}
