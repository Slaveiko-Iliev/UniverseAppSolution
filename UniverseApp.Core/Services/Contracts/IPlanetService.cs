using UniverseApp.Core.Models.Planet;

namespace UniverseApp.Core.Services.Contracts
{
	public interface IPlanetService
	{
		Task<int> AddPlanetAsync(PlanetFormModel model);

		Task EditPlanetAsync(int id, PlanetFormModel model);

		Task<bool> ExistByIdAsync(int id);

		Task<PlanetQueryServiceModel> GetAllPlanetsAsync(string? searchCharacter, string? searchMovie, int currentPage, int planetsPerPage);

		Task<PlanetFormModel> GetPlanetFormByIdAsync(int id);

		Task<PlanetDetailsViewModel> GetSpecieDetailsByIdAsync(int id);
	}
}
