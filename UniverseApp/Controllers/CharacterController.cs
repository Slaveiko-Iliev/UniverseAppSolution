﻿using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Models.Character;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Data.Models;

using static UniverseApp.Infrastructure.Constants.JediConstants;

namespace UniverseApp.Controllers

{
    public class CharacterController : BaseController
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
            {
                return Unauthorized();
            }

            var model = new CharacterFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CharacterFormModel model)
        {
            if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int newCharacterId = await _characterService.AddCharacterAsync(model);

            return RedirectToAction(nameof(Details), new { id = newCharacterId });
        }

        public async Task<IActionResult> All([FromQuery] CharacterAllQueryModel model)
        {
            var queryResult = await _characterService.GetAllCharactersAsync(model.SearchMovie, model.SearchSpecie, model.SearchVehicle, model.SearchStarship, model.CurrentPage, CharacterAllQueryModel.CharactersPerPage);

            model.Characters = queryResult.Characters;
            model.TotalCharactersCount = queryResult.TotalCharactersCount;

            return View(model);
        }

        [CheckIsDeleted<Character>]
        public async Task<IActionResult> Details(int id)
        {
            if (await _characterService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            CharacterDetailsViewModel model = await _characterService.GetCharacterDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        [CheckIsDeleted<Character>]
        public async Task<IActionResult> Edit(int id)
        {
            if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
            {
                return Unauthorized();
            }

            if (await _characterService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await _characterService.GetCharacterFormByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        [CheckIsDeleted<Character>]
        public async Task<IActionResult> Edit(int id, CharacterFormModel model)
        {
            if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _characterService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            await _characterService.EditCharacterAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        [CheckIsDeleted<Character>]
        public async Task<IActionResult> Delete(int id)
        {

            if (!User.IsInRole(YodaRoleName))
            {
                return Unauthorized();
            }

            if (await _characterService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await _characterService.GetCharacterDeleteModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        [CheckIsDeleted<Character>]
        public async Task<IActionResult> Delete(int id, CharacterDeleteViewModel model)
        {
            if (!User.IsInRole(YodaRoleName))
            {
                return Unauthorized();
            }
            if (await _characterService.ExistByIdAsync(model.Id) == false)
            {
                return BadRequest();
            }
            if (id != model.Id)
            {
                return BadRequest();
            }

            await _characterService.DeleteCharacterAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
