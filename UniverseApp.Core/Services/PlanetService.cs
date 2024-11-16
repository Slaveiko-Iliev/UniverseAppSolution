using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;

namespace UniverseApp.Core.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IRepository _repository;

        public PlanetService(IRepository repository)
        {
            _repository = repository;
        }

    }
}
