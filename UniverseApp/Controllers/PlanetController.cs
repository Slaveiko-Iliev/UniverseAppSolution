using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Models.Planet;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Constants.JediConstants;

namespace UniverseApp.Controllers
{
    public class PlanetController : BaseController
    {
        private readonly IPlanetService _planetService;
        private readonly IUserService _userService;

        public PlanetController(IPlanetService planetService, IUserService userService)
        {
            _planetService = planetService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
            {
                return Unauthorized();
            }

            var model = new PlanetFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PlanetFormModel model)
        {
            if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int newPlanetId = await _planetService.AddPlanetAsync(model);

            return RedirectToAction(nameof(Details), new { id = newPlanetId });
        }

        public async Task<IActionResult> All([FromQuery] PlanetAllQueryModel model)
        {
            PlanetQueryServiceModel queryResult = await _planetService.GetAllPlanetsAsync(model.SearchCharacter, model.SearchMovie, model.CurrentPage, PlanetAllQueryModel.PlanetsPerPage);

            model.Planets = queryResult.Planets;
            model.TotalPlanetsCount = queryResult.TotalPlanetsCount;

            return View(model);
        }

        [CheckIsDeleted<Planet>]
        public async Task<IActionResult> Details(int id)
        {
            if (await _planetService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await _planetService.GetSpecieDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        [CheckIsDeleted<Planet>]
        public async Task<IActionResult> Edit(int id)
        {
            if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
            {
                return Unauthorized();
            }

            if (await _planetService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var planet = await _planetService.GetPlanetFormByIdAsync(id);

            return View(planet);
        }

        [HttpPost]
        [CheckIsDeleted<Planet>]
        public async Task<IActionResult> Edit(int id, PlanetFormModel model)
        {
            if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _planetService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            await _planetService.EditPlanetAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        [CheckIsDeleted<Planet>]
        public async Task<IActionResult> Delete(int id)
        {

            if (!User.IsInRole(YodaRoleName))
            {
                return Unauthorized();
            }

            if (await _planetService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await _planetService.GetPlanetDeleteModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        [CheckIsDeleted<Planet>]
        public async Task<IActionResult> Delete(int id, PlanetDeleteViewModel model)
        {
            if (!User.IsInRole(YodaRoleName))
            {
                return Unauthorized();
            }
            if (await _planetService.ExistByIdAsync(model.Id) == false)
            {
                return BadRequest();
            }
            if (id != model.Id)
            {
                return BadRequest();
            }

            await _planetService.DeletePlanetAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
