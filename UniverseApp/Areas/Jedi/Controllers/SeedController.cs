using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Areas.Jedi.Controllers
{
    public class SeedController : JediBaseController
    {
        private readonly ISeedHelper _seedHelper;
        private readonly IPlanetService _planetService;
        private readonly IMovieService _movieService;
        private readonly ISpecieService _specieService;
        private readonly ICharacterService _characterService;
        private readonly IStarshipService _starshipService;
        private readonly IVehicleService _vehicleService;

        public SeedController(ISeedHelper seedHelper, IPlanetService planetService, IMovieService movieService, ISpecieService specieService, ICharacterService characterService, IStarshipService starshipService, IVehicleService vehicleService)
        {
            _seedHelper = seedHelper;
            _planetService = planetService;
            _movieService = movieService;
            _specieService = specieService;
            _characterService = characterService;
            _starshipService = starshipService;
            _vehicleService = vehicleService;
        }

        public async Task<IActionResult> SeedMovies()
        {
            var movieDtoList = await _seedHelper.GetMovieDtoInfoAsync<MovieInfoDto>();

            await _movieService.AddMovieRangeAsync(movieDtoList);

            return View();
        }

        public async Task<IActionResult> SeedPlanets()
        {
            var planetIdDtoList = await _seedHelper.GetEntityIdDtoAsync<PlanetInfoDto>();

            var planetDtoList = await _seedHelper.GetEntityDtoInfoAsync<PlanetInfoDto>(planetIdDtoList);

            await _planetService.AddPlanetRangeAsync(planetDtoList);

            return View();
        }

        public async Task<IActionResult> SeedCharacters()
        {
            var charactersIdDtoList = await _seedHelper.GetEntityIdDtoAsync<CharacterInfoDto>();

            var charactersDtoList = await _seedHelper.GetEntityDtoInfoAsync<CharacterInfoDto>(charactersIdDtoList);

            await _characterService.AddCharactersRangeAsync(charactersDtoList);

            return View();
        }

        public async Task<IActionResult> SeedSpecies()
        {
            var specieIdDtoList = await _seedHelper.GetEntityIdDtoAsync<SpecieInfoDto>();

            var specieDtoList = await _seedHelper.GetEntityDtoInfoAsync<SpecieInfoDto>(specieIdDtoList);

            await _specieService.AddSpecieRangeAsync(specieDtoList);

            return View();
        }

        public async Task<IActionResult> SeedStarships()
        {
            var starshipIdDtoList = await _seedHelper.GetEntityIdDtoAsync<StarshipInfoDto>();

            var starshipDtoList = await _seedHelper.GetEntityDtoInfoAsync<StarshipInfoDto>(starshipIdDtoList);

            await _starshipService.AddStarshipRangeAsync(starshipDtoList);

            return View();
        }

        public async Task<IActionResult> SeedVehicles()
        {
            var vehiclesIdDtoList = await _seedHelper.GetEntityIdDtoAsync<VehicleInfoDto>();

            var vehiclesDtoList = await _seedHelper.GetEntityDtoInfoAsync<VehicleInfoDto>(vehiclesIdDtoList);

            await _vehicleService.AddVehiclesRangeAsync(vehiclesDtoList);

            return View();
        }

        public async Task<IActionResult> SeedMovieRelationship()
        {
            var movieDtoList = await _seedHelper.GetMovieDtoInfoAsync<MovieInfoDto>();

            await _movieService.AddMovieRelationshipAsync(movieDtoList);

            return View();
        }
    }
}
