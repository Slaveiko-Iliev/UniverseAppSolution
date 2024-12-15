using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Models.Planet;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IRepository _repository;
        private readonly IServiceHelper _serviceHelper;

        public PlanetService(IRepository repository, IServiceHelper serviceHelper)
        {
            _repository = repository;
            _serviceHelper = serviceHelper;
        }

        public async Task<int> AddPlanetAsync(PlanetFormModel model)
        {
            int? rotationPeriod = model.RotationPeriod != null
                ? int.Parse(model.RotationPeriod)
                : null;
            int? orbitalPeriod = model.OrbitalPeriod != null
                ? int.Parse(model.OrbitalPeriod)
                : null;
            double? surfaceWater = model.SurfaceWater != null
                ? double.Parse(model.SurfaceWater)
                : null;
            int? population = model.Population != null
                ? int.Parse(model.Population)
                : null;

            var newPlanet = new Planet()
            {
                Id = _repository.AllReadOnly<Planet>().Count() + 1,
                Name = model.Name,
                RotationPeriod = rotationPeriod,
                OrbitalPeriod = orbitalPeriod,
                Climate = _serviceHelper.SplitInput(model.Climate!),
                Gravity = model.Gravity,
                Terrain = _serviceHelper.SplitInput(model.Terrain!),
                SurfaceWater = surfaceWater,
                Population = population,
                Characters = model.CharacterIds != null
                    ? await _serviceHelper.GetEntitiesByIds<Character>(_serviceHelper.GetParsedIds(model.CharacterIds))
                    : [],
                Movies = model.MovieIds != null
                    ? await _serviceHelper.GetEntitiesByIds<Movie>(_serviceHelper.GetParsedIds(model.MovieIds))
                    : []
            };

            await _repository.AddAsync(newPlanet);
            await _repository.SaveChangesAsync();

            return newPlanet.Id;
        }

        public async Task DeletePlanetAsync(int id)
        {
            var planet = await _repository
                .All<Planet>()
                .FirstAsync(m => m.Id == id);

            planet.IsDeleted = true;
            await _repository.SaveChangesAsync();
        }

        public async Task EditPlanetAsync(int id, PlanetFormModel model)
        {
            var movie = await _repository
                .GetEntityByIdAsync<Planet>(id);

            movie.Name = model.Name;
            movie.RotationPeriod = model.RotationPeriod != null
                ? _serviceHelper.TryParseInputToInt(model.RotationPeriod)
                : null;
            movie.OrbitalPeriod = model.OrbitalPeriod != null
                ? _serviceHelper.TryParseInputToInt(model.OrbitalPeriod)
                : null;
            movie.Climate = _serviceHelper.SplitInput(model.Climate!);
            movie.Gravity = model.Gravity;
            movie.Terrain = _serviceHelper.SplitInput(model.Terrain!);
            movie.SurfaceWater = model.SurfaceWater != null
                ? _serviceHelper.TryParseInputToDouble(model.SurfaceWater)
                : null;
            movie.Population = model.Population != null
                ? _serviceHelper.TryParseInputToInt(model.Population)
                : null;

            await _repository.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(int id) =>
            await _repository
                .AllReadOnly<Planet>()
                .Where(m => !m.IsDeleted)
                .AnyAsync(m => m.Id == id);

        public async Task<PlanetQueryServiceModel> GetAllPlanetsAsync(string? searchCharacter, string? searchMovie, int currentPage, int planetsPerPage)
        {
            var planets = _repository
                .AllReadOnly<Planet>()
                .Where(ch => !ch.IsDeleted);

            if (!string.IsNullOrEmpty(searchCharacter))
            {
                planets = planets
                    .Where(m => m.Characters.Any(c => c.Name == searchCharacter));
            }

            if (!string.IsNullOrEmpty(searchMovie))
            {
                planets = planets
                    .Where(m => m.Movies.Any(p => p.Name == searchMovie));
            }

            var totalPlanetsCount = await planets.CountAsync();

            planets = planets
                .OrderBy(m => m.Id)
                .Skip((currentPage - 1) * planetsPerPage)
                .Take(planetsPerPage);

            var planetViewModels = await planets
                .Select(m => new PlanetAllViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    RotationPeriod = m.RotationPeriod.ToString(),
                    OrbitalPeriod = m.OrbitalPeriod.ToString(),
                    Climate = string.Join(", ", m.Climate) ?? string.Empty,
                    Gravity = m.Gravity,
                    Terrain = string.Join(", ", m.Terrain) ?? string.Empty,
                    SurfaceWater = m.SurfaceWater.ToString(),
                    Population = m.Population.ToString(),
                })
                .ToListAsync();

            var planetAllQueryModels = new PlanetQueryServiceModel()
            {
                TotalPlanetsCount = totalPlanetsCount,
                Planets = planetViewModels
            };

            return planetAllQueryModels;
        }

        public async Task<PlanetDeleteViewModel> GetPlanetDeleteModelByIdAsync(int id)
        {
            var planet = await _repository
                .GetEntityByIdAsync<Planet>(id);

            var planetDeleteModel = new PlanetDeleteViewModel
            {
                Name = planet.Name,
                RotationPeriod = planet.RotationPeriod.ToString(),
                OrbitalPeriod = planet.OrbitalPeriod.ToString(),
                Population = planet.Population.ToString()
            };

            return planetDeleteModel;
        }

        public async Task<PlanetFormModel> GetPlanetFormByIdAsync(int id)
        {
            var planet = await _repository
                .GetEntityByIdAsync<Planet>(id);

            var planetFormModel = new PlanetFormModel
            {
                Name = planet.Name,
                RotationPeriod = planet.RotationPeriod.ToString(),
                OrbitalPeriod = planet.OrbitalPeriod.ToString(),
                Climate = planet.Climate != null
                    ? string.Join(", ", planet.Climate)
                    : string.Empty,
                Gravity = planet.Gravity,
                Terrain = planet.Terrain != null
                    ? string.Join(", ", planet.Terrain)
                    : string.Empty,
                SurfaceWater = planet.SurfaceWater.ToString(),
                Population = planet.Population.ToString()
            };

            return planetFormModel;
        }

        public async Task<PlanetDetailsViewModel> GetSpecieDetailsByIdAsync(int id)
        {
            var planet = await _repository
                .GetEntityByIdAsync<Planet>(id);

            var charactersNames = await _repository.GetEntitiesNames<Character>(planet.Characters);
            var speciesNames = await _repository.GetEntitiesNames<Specie>(planet.Species);
            var moviesNames = await _repository.GetEntitiesNames<Movie>(planet.Movies);

            var planetDetails = new PlanetDetailsViewModel
            {
                Id = planet.Id,
                Name = planet.Name,
                RotationPeriod = planet.RotationPeriod.ToString(),
                OrbitalPeriod = planet.OrbitalPeriod.ToString(),
                Climate = planet.Climate != null ? string.Join(", ", planet.Climate) : string.Empty,
                Gravity = planet.Gravity,
                Terrain = planet.Terrain != null ? string.Join(", ", planet.Terrain) : string.Empty,
                SurfaceWater = planet.SurfaceWater.ToString(),
                Population = planet.Population.ToString(),
                CharactersNames = charactersNames,
                SpeciesNames = speciesNames,
                MoviesNames = moviesNames
            };

            return planetDetails;
        }
    }
}
