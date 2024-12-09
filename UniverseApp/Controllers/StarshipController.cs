using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Models.Starship;
using UniverseApp.Core.Services.Contracts;

namespace UniverseApp.Controllers
{
    public class StarshipController : BaseController
    {
        private readonly IStarshipService _starshipService;

        public StarshipController(IStarshipService starshipService)
        {
            _starshipService = starshipService;
        }

        public async Task<IActionResult> All([FromQuery] StarshipAllQueryModel model)
        {
            StarshipQueryServiceModel queryResult = await _starshipService.GetAllStarshipsAsync(model.SearchCharacter, model.SearchMovie, model.CurrentPage, StarshipAllQueryModel.StarshipsPerPage);

            model.Starships = queryResult.Starships;
            model.TotalStarshipsCount = queryResult.TotalStarshipsCount;

            return View(model);
        }
    }
}
