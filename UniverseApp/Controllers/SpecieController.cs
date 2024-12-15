using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Models.Specie;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Constants.JediConstants;

namespace UniverseApp.Controllers
{
	public class SpecieController : BaseController
	{
		private readonly ISpecieService _specieService;

		public SpecieController(ISpecieService specieService)
		{
			_specieService = specieService;
		}

		[HttpGet]
		public IActionResult Add()
		{
			if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
			{
				return Unauthorized();
			}

			var model = new SpecieFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(SpecieFormModel model)
		{
			if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
			{
				return Unauthorized();
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			int newSpecieId = await _specieService.AddSpecieAsync(model);

			return RedirectToAction(nameof(Details), new { id = newSpecieId });
		}

		public async Task<IActionResult> All([FromQuery] SpecieAllQueryModel model)
		{
			SpecieQueryServiceModel queryResult = await _specieService.GetAllSpeciesAsync(model.SearchCharacter, model.SearchMovie, model.CurrentPage, SpecieAllQueryModel.SpeciesPerPage);

			model.Species = queryResult.Species;
			model.TotalSpeciesCount = queryResult.TotalSpeciesCount;

			return View(model);
		}

		[CheckIsDeleted<Specie>]
		public async Task<IActionResult> Details(int id)
		{
			if (await _specieService.ExistByIdAsync(id) == false)
			{
				return BadRequest();
			}

			var model = await _specieService.GetSpecieDetailsByIdAsync(id);

			return View(model);
		}
	}
}
