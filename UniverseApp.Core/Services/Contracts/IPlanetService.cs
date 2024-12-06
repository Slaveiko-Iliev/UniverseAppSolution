using UniverseApp.Core.Models.Planet;

namespace UniverseApp.Core.Services.Contracts
{
    public interface IPlanetService
    {
        Task AddPlanetAsync(PlanetFormModel model);
        Task<PlanetQueryServiceModel> GetAllPlanetsAsync(string? searchCharacter, string? searchMovie, int currentPage, int planetsPerPage);
    }
}
