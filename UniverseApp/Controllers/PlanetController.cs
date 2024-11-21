using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Models.Planet;
using UniverseApp.Core.Services.Contracts;

namespace UniverseApp.Controllers
{
    public class PlanetController : BaseController
    {
        private readonly IPlanetService _planetService;

        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (User.Identity?.IsAuthenticated == false)
            {
                return Unauthorized();
            }

            var model = new PlanetFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PlanetFormModel model)
        {
            if (User.Identity?.IsAuthenticated == false)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _planetService.AddPlanetAsync(model);

            return RedirectToAction("All");
        }


    }
}
