using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Models.Specie;
using UniverseApp.Core.Services.Contracts;

namespace UniverseApp.Controllers
{
    public class SpecieController : BaseController
    {
        private readonly ISpecieService _specieService;

        public SpecieController(ISpecieService specieService)
        {
            _specieService = specieService;
        }

        public async Task<IActionResult> All([FromQuery] SpecieAllQueryModel model)
        {
            SpecieQueryServiceModel queryResult = await _specieService.GetAllSpeciesAsync(model.SearchCharacter, model.SearchMovie, model.CurrentPage, SpecieAllQueryModel.SpeciesPerPage);

            model.Species = queryResult.Species;
            model.TotalSpeciesCount = queryResult.TotalSpeciesCount;

            return View(model);
        }
    }
}
