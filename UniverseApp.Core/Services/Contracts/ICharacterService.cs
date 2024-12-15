using UniverseApp.Core.Models.Character;

namespace UniverseApp.Core.Services.Contracts
{
	public interface ICharacterService
	{
		Task<int> AddCharacterAsync(CharacterFormModel model);
		Task EditCharacterAsync(int id, CharacterFormModel model);
		Task<bool> ExistByIdAsync(int id);

		Task<CharacterQueryServiceModel> GetAllCharactersAsync(string? searchMovie, string? searchSpecie, string? searchVehicle, string? searchStarship, int currentPage, int charactersPerPage);

		Task<CharacterDetailsViewModel> GetCharacterDetailsByIdAsync(int id);

		Task<CharacterFormModel> GetCharacterFormByIdAsync(int id);
	}
}
