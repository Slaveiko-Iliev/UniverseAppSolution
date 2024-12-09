using UniverseApp.Core.Models.Starship;

namespace UniverseApp.Core.Services.Contracts
{
    public interface IStarshipService
    {
        Task<StarshipQueryServiceModel> GetAllStarshipsAsync(string? searchCharacter, string? searchMovie, int currentPage, int starshipsPerPage);
    }
}
