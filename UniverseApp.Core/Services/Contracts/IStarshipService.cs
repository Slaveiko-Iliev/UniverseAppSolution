using UniverseApp.Core.Models.Starship;
using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Core.Services.Contracts
{
	public interface IStarshipService
	{
		Task<int> AddStarshipAsync(StarshipFormModel model);
        Task AddStarshipRangeAsync(List<StarshipInfoDto> starshipDtoList);
        Task DeleteStarshipAsync(int id);
        Task EditStarshipAsync(int id, StarshipFormModel model);
		Task<bool> ExistByIdAsync(int id);

		Task<StarshipQueryServiceModel> GetAllStarshipsAsync(string? searchCharacter, string? searchMovie, int currentPage, int starshipsPerPage);
        Task<StarshipDeleteViewModel> GetStarshipDeleteModelByIdAsync(int id);
        Task<StarshipDetailsViewModel> GetStarshipDetailsByIdAsync(int id);
		Task<StarshipFormModel> GetStarshipFormByIdAsync(int id);
	}
}
