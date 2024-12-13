using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Models.Planet;
using UniverseApp.Core.Services.Contracts;
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

			await _planetService.AddPlanetAsync(model);

			return RedirectToAction("All");
		}

		public async Task<IActionResult> All([FromQuery] PlanetAllQueryModel model)
		{
			PlanetQueryServiceModel queryResult = await _planetService.GetAllPlanetsAsync(model.SearchCharacter, model.SearchMovie, model.CurrentPage, PlanetAllQueryModel.PlanetsPerPage);

			model.Planets = queryResult.Planets;
			model.TotalPlanetsCount = queryResult.TotalPlanetsCount;

			return View(model);
		}
	}
}
