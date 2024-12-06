using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Models.Movie;
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

        public async Task AddPlanetAsync(PlanetFormModel model)
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
        }

        public async Task<PlanetQueryServiceModel> GetAllPlanetsAsync(string? searchCharacter, string? searchMovie, int currentPage, int planetsPerPage)
        {
            var planets = _repository
                .AllReadOnly<Planet>();

            if (!string.IsNullOrEmpty(searchCharacter))
            {
                planets = planets
                    .Where(m => m.Characters.Any(c => c.Name == searchCharacter));
            }

            if (!string.IsNullOrEmpty(searchMovie))
            {
                planets = planets
                    .Where(m => m.Movies.Any(p => p.Title == searchMovie));
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
                    Climate = string.Join(", ",m.Climate) ?? string.Empty,
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
    }
}
