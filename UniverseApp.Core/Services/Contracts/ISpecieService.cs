using UniverseApp.Core.Models.Specie;

namespace UniverseApp.Core.Services.Contracts
{
    public interface ISpecieService
    {
        Task<SpecieQueryServiceModel> GetAllSpeciesAsync(string? searchCharacter, string? searchMovie, int currentPage, int speciesPerPage);
    }
}
