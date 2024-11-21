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
            var newPlanet = new Planet()
            {
                Id = _repository.AllReadOnly<Planet>().Count() + 1,
                Name = model.Name,
                RotationPeriod = model.RotationPeriod,
                OrbitalPeriod = model.OrbitalPeriod,
                Climate = _serviceHelper.SplitInput(model.Climate!),
                Gravity = model.Gravity,
                Terrain = _serviceHelper.SplitInput(model.Terrain!),
                SurfaceWater = model.SurfaceWater,
                Population = model.Population,
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
    }
}
