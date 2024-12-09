using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Models.Character;
using UniverseApp.Core.Services.Contracts;

namespace UniverseApp.Controllers
{
    public class CharacterController : BaseController
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        public async Task<IActionResult> All([FromQuery] CharacterAllQueryModel model)
        {
            CharacterQueryServiceModel queryResult = await _characterService.GetAllCharactersAsync(model.SearchMovie, model.SearchSpecie, model.SearchVehicle, model.SearchStarship, model.CurrentPage, CharacterAllQueryModel.CharactersPerPage);

            model.Characters = queryResult.Characters;
            model.TotalCharactersCount = queryResult.TotalCharactersCount;

            return View(model);
        }
    }
}
