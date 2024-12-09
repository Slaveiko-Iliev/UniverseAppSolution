using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Models.Starship;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services
{
    public class StarshipService : IStarshipService
    {
        private readonly IRepository _repository;

        public StarshipService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<StarshipQueryServiceModel> GetAllStarshipsAsync(string? searchCharacter, string? searchMovie, int currentPage, int starshipsPerPage)
        {
            var starships = _repository
                .AllReadOnly<Starship>();

            if (!string.IsNullOrEmpty(searchCharacter))
            {
                starships = starships
                    .Where(v => v.Characters.Any(ch => ch.Name == searchCharacter));
            }

            if (!string.IsNullOrEmpty(searchMovie))
            {
                starships = starships
                    .Where(v => v.Movies.Any(m => m.Title == searchMovie));
            }

            var totalStarshipsCount = await starships.CountAsync();

            starships = starships
                .OrderBy(m => m.Id)
                .Skip((currentPage - 1) * starshipsPerPage)
                .Take(starshipsPerPage);

            var starshipViewModels = await starships
                .Select(m => new StarshipAllViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Model = m.Model,
                    Manufacturer = m.Manufacturer,
                    CostInCredits = m.CostInCredits.ToString(),
                    Length = m.Length.ToString(),
                    MaxAtmospheringSpeed = m.MaxAtmospheringSpeed.ToString(),
                    Crew = m.Crew.ToString(),
                    Passengers = m.Passengers.ToString(),
                    CargoCapacity = m.CargoCapacity.ToString(),
                    Consumables = m.Consumables,
                    Class = m.Class,
                    HyperdriveRating = m.HyperdriveRating.ToString(),
                    MGLT = m.MGLT.ToString()
                })
                .ToListAsync();

            var starshipAllQueryModels = new StarshipQueryServiceModel()
            {
                TotalStarshipsCount = totalStarshipsCount,
                Starships = starshipViewModels
            };

            return starshipAllQueryModels;
        }
    }
}
