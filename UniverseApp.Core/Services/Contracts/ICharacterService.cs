using UniverseApp.Core.Models.Character;

namespace UniverseApp.Core.Services.Contracts
{
    public interface ICharacterService
    {
        Task<CharacterQueryServiceModel> GetAllCharactersAsync(string? searchMovie, string? searchSpecie, string? searchVehicle, string? searchStarship, int currentPage, int charactersPerPage);
    }
}
