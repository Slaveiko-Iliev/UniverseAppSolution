using UniverseApp.Core.Models.Planet;

namespace UniverseApp.Core.Services.Contracts
{
	public interface IPlanetService
	{
		Task<int> AddPlanetAsync(PlanetFormModel model);

		Task<bool> ExistByIdAsync(int id);

		Task<PlanetQueryServiceModel> GetAllPlanetsAsync(string? searchCharacter, string? searchMovie, int currentPage, int planetsPerPage);

		Task<PlanetDetailsViewModel> GetSpecieDetailsByIdAsync(int id);
	}
}
