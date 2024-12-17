using UniverseApp.Core.Models.Planet;
using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Core.Services.Contracts
{
    public interface IPlanetService
    {
        Task<int> AddPlanetAsync(PlanetFormModel model);
        Task AddPlanetRangeAsync(List<PlanetInfoDto> planetDtoList);
        Task DeletePlanetAsync(int id);
        Task EditPlanetAsync(int id, PlanetFormModel model);

        Task<bool> ExistByIdAsync(int id);

        Task<PlanetQueryServiceModel> GetAllPlanetsAsync(string? searchCharacter, string? searchMovie, int currentPage, int planetsPerPage);

        Task<PlanetDeleteViewModel> GetPlanetDeleteModelByIdAsync(int id);

        Task<PlanetFormModel> GetPlanetFormByIdAsync(int id);

        Task<PlanetDetailsViewModel> GetSpecieDetailsByIdAsync(int id);
    }
}
