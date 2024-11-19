using UniverseApp.Core.Services;

namespace UniverseApp.Controllers
{
    public class PlanetController : BaseController
    {
        private readonly PlanetService _planetService;

        public PlanetController(PlanetService planetService)
        {
            _planetService = planetService;
        }


    }
}
