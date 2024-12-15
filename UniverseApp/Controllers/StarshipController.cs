using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Models.Starship;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Constants.JediConstants;

namespace UniverseApp.Controllers
{
	public class StarshipController : BaseController
	{
		private readonly IStarshipService _starshipService;

		public StarshipController(IStarshipService starshipService)
		{
			_starshipService = starshipService;
		}

		[HttpGet]
		public IActionResult Add()
		{
			if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
			{
				return Unauthorized();
			}

			var model = new StarshipFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(StarshipFormModel model)
		{
			if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
			{
				return Unauthorized();
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			int newStarshipId = await _starshipService.AddStarshipAsync(model);

			return RedirectToAction(nameof(Details), new { id = newStarshipId });
		}

		public async Task<IActionResult> All([FromQuery] StarshipAllQueryModel model)
		{
			StarshipQueryServiceModel queryResult = await _starshipService.GetAllStarshipsAsync(model.SearchCharacter, model.SearchMovie, model.CurrentPage, StarshipAllQueryModel.StarshipsPerPage);

			model.Starships = queryResult.Starships;
			model.TotalStarshipsCount = queryResult.TotalStarshipsCount;

			return View(model);
		}

		[CheckIsDeleted<Starship>]
		public async Task<IActionResult> Details(int id)
		{
			if (await _starshipService.ExistByIdAsync(id) == false)
			{
				return BadRequest();
			}

			var model = await _starshipService.GetSpecieDetailsByIdAsync(id);

			return View(model);
		}
	}
}
