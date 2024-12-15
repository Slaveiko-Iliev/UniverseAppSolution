using UniverseApp.Core.Models.Starship;

namespace UniverseApp.Core.Services.Contracts
{
	public interface IStarshipService
	{
		Task<int> AddStarshipAsync(StarshipFormModel model);

		Task<bool> ExistByIdAsync(int id);

		Task<StarshipQueryServiceModel> GetAllStarshipsAsync(string? searchCharacter, string? searchMovie, int currentPage, int starshipsPerPage);

		Task<StarshipDetailsViewModel> GetSpecieDetailsByIdAsync(int id);
	}
}
