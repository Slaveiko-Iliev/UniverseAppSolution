using UniverseApp.Core.Models.Specie;

namespace UniverseApp.Core.Services.Contracts
{
	public interface ISpecieService
	{
		Task<int> AddSpecieAsync(SpecieFormModel model);
        Task DeleteSpecieAsync(int id);
        Task EditSpecieAsync(int id, SpecieFormModel model);

		Task<bool> ExistByIdAsync(int id);

		Task<SpecieQueryServiceModel> GetAllSpeciesAsync(string? searchCharacter, string? searchMovie, int currentPage, int speciesPerPage);
        Task<SpecieDeleteViewModel> GetSpecieDeleteModelByIdAsync(int id);
        Task<SpecieDetailsViewModel> GetSpecieDetailsByIdAsync(int id);

		Task<SpecieFormModel> GetSpecieFormByIdAsync(int id);
	}
}
