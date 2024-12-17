using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Models.Starship;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.DTOs;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services
{
    public class StarshipService : IStarshipService
    {
        private readonly IRepository _repository;
        private readonly IServiceHelper _serviceHelper;

        public StarshipService(IRepository repository, IServiceHelper serviceHelper)
        {
            _repository = repository;
            _serviceHelper = serviceHelper;
        }

        public async Task<int> AddStarshipAsync(StarshipFormModel model)
        {
            int? costInCredits = model.CostInCredits != null
                ? _serviceHelper.TryParseInputToInt(model.CostInCredits)
                : null;
            double? length = model.Length != null
                ? _serviceHelper.TryParseInputToDouble(model.Length)
                : null;
            int? maxAtmospheringSpeed = model.MaxAtmospheringSpeed != null
                ? _serviceHelper.TryParseInputToInt(model.MaxAtmospheringSpeed)
                : null;
            int? crew = model.Crew != null
                ? _serviceHelper.TryParseInputToInt(model.Crew)
                : null;
            int? passengers = model.Passengers != null
                ? _serviceHelper.TryParseInputToInt(model.Passengers)
                : null;
            int? cargoCapacity = model.CargoCapacity != null
                ? _serviceHelper.TryParseInputToInt(model.CargoCapacity)
                : null;
            double? hyperdriveRating = model.HyperdriveRating != null
                ? _serviceHelper.TryParseInputToDouble(model.HyperdriveRating)
                : null;
            int? mglt = model.MGLT != null
                ? _serviceHelper.TryParseInputToInt(model.MGLT)
                : null;

            var newStarship = new Starship()
            {
                Id = _repository.AllReadOnly<Starship>().Count() + 40,
                Name = model.Name,
                Model = model.StarshipModel,
                Manufacturer = model.Manufacturer,
                CostInCredits = costInCredits,
                Length = length,
                MaxAtmospheringSpeed = maxAtmospheringSpeed,
                Crew = crew,
                Passengers = passengers,
                CargoCapacity = cargoCapacity,
                Consumables = model.Consumables,
                Class = model.Class,
                HyperdriveRating = hyperdriveRating,
                MGLT = mglt
            };

            await _repository.AddAsync(newStarship);
            await _repository.SaveChangesAsync();

            return newStarship.Id;
        }

        public async Task AddStarshipRangeAsync(List<StarshipInfoDto> starshipDtoList)
        {
            ICollection<Starship> starships = new List<Starship>();

            foreach (var starshipDto in starshipDtoList)
            {
                var starshipId = _serviceHelper.GetEntityIdFromUrl(starshipDto.Url);

                if (!await _repository.AllReadOnly<Starship>().AnyAsync(p => p.Id == starshipId)
                    && !await _repository.AllReadOnly<Starship>().AnyAsync(p => p.Name == starshipDto.Name))
                {
                    var newStarship = new Starship()
                    {
                        Id = starshipId,
                        Name = starshipDto.Name,
                        Model = starshipDto.Model,
                        Manufacturer = starshipDto.Manufacturer,
                        CostInCredits = starshipDto.CostInCredits != null
                            ? _serviceHelper.TryParseInputToInt(starshipDto.CostInCredits)
                            : null,
                        Length = starshipDto.Length != null
                        ? _serviceHelper.TryParseInputToDouble(starshipDto.Length)
                            : null,
                        MaxAtmospheringSpeed = starshipDto.MaxAtmospheringSpeed != null
                        ? _serviceHelper.TryParseInputToInt(starshipDto.MaxAtmospheringSpeed)
                            : null,
                        Crew = starshipDto.Crew != null
                        ? _serviceHelper.TryParseInputToInt(starshipDto.Crew)
                            : null,
                        Passengers = starshipDto.Passengers != null
                        ? _serviceHelper.TryParseInputToInt(starshipDto.Passengers)
                            : null,
                        CargoCapacity = starshipDto.CargoCapacity != null
                        ? _serviceHelper.TryParseInputToInt(starshipDto.CargoCapacity)
                            : null,
                        Consumables = starshipDto.Consumables,
                        Class = starshipDto.Class,
                        HyperdriveRating = starshipDto.HyperdriveRating != null
                        ? _serviceHelper.TryParseInputToDouble(starshipDto.HyperdriveRating)
                            : null,
                        MGLT = starshipDto.MGLT != null
                        ? _serviceHelper.TryParseInputToInt(starshipDto.MGLT)
                            : null,
                        Url = starshipDto.Url
                    };

                    if (starshipDto.Pilots != null)
                    {
                        foreach (var characterUrl in starshipDto.Pilots)
                        {
                            var characterId = _serviceHelper.GetEntityIdFromUrl(characterUrl);
                            if (!await _repository.AllReadOnly<Character>().AnyAsync(ch => ch.Id == characterId))
                            {
                                continue;
                            }

                            var character = await _repository.GetEntityByIdAsync<Character>(characterId);
                            newStarship.Characters.Add(character);
                        }
                    }

                    starships.Add(newStarship);
                }
            }
            await _repository.AddRangeAsync(starships);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteStarshipAsync(int id)
        {
            var starship = await _repository
                .All<Starship>()
                .FirstAsync(m => m.Id == id);

            starship.IsDeleted = true;
            await _repository.SaveChangesAsync();
        }

        public async Task EditStarshipAsync(int id, StarshipFormModel model)
        {
            var starship = await _repository
                .GetEntityByIdAsync<Starship>(id);

            starship.Name = model.Name;
            starship.Model = model.StarshipModel;
            starship.Manufacturer = model.Manufacturer;
            starship.CostInCredits = model.CostInCredits != null
                ? _serviceHelper.TryParseInputToInt(model.CostInCredits)
                : null;
            starship.Length = model.Length != null
                ? _serviceHelper.TryParseInputToDouble(model.Length)
                : null;
            starship.MaxAtmospheringSpeed = model.MaxAtmospheringSpeed != null
                ? _serviceHelper.TryParseInputToInt(model.MaxAtmospheringSpeed)
                : null;
            starship.Crew = model.Crew != null
                ? _serviceHelper.TryParseInputToInt(model.Crew)
                : null;
            starship.Passengers = model.Passengers != null
                ? _serviceHelper.TryParseInputToInt(model.Passengers)
                : null;
            starship.CargoCapacity = model.CargoCapacity != null
                ? _serviceHelper.TryParseInputToInt(model.CargoCapacity)
                : null;
            starship.Consumables = model.Consumables;
            starship.Class = model.Class;
            starship.HyperdriveRating = model.HyperdriveRating != null
                ? _serviceHelper.TryParseInputToDouble(model.HyperdriveRating)
                : null;
            starship.MGLT = model.MGLT != null
                ? _serviceHelper.TryParseInputToInt(model.MGLT)
                : null;

            await _repository.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(int id) =>
            await _repository
                .AllReadOnly<Starship>()
                .Where(m => !m.IsDeleted)
                .AnyAsync(m => m.Id == id);

        public async Task<StarshipQueryServiceModel> GetAllStarshipsAsync(string? searchCharacter, string? searchMovie, int currentPage, int starshipsPerPage)
        {
            var starships = _repository
                .AllReadOnly<Starship>()
                .Where(v => !v.IsDeleted);

            if (!string.IsNullOrEmpty(searchCharacter))
            {
                starships = starships
                    .Where(v => v.Characters.Any(ch => ch.Name == searchCharacter));
            }

            if (!string.IsNullOrEmpty(searchMovie))
            {
                starships = starships
                    .Where(v => v.Movies.Any(m => m.Name == searchMovie));
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
                    StarshipModel = m.Model,
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

        public async Task<StarshipDeleteViewModel> GetStarshipDeleteModelByIdAsync(int id)
        {
            var starship = await _repository
                .GetEntityByIdAsync<Starship>(id);

            var starshipDeleteModel = new StarshipDeleteViewModel
            {
                Id = starship.Id,
                Name = starship.Name,
                StarshipModel = starship.Model,
                Manufacturer = starship.Manufacturer,
                StarshipClass = starship.Class
            };

            return starshipDeleteModel;
        }

        public async Task<StarshipDetailsViewModel> GetStarshipDetailsByIdAsync(int id)
        {
            var starship = await _repository
                .GetEntityByIdAsync<Starship>(id);

            var charactersNames = await _repository.GetEntitiesNames<Character>(starship.Characters);
            var moviesNames = await _repository.GetEntitiesNames<Movie>(starship.Movies);

            var starshipDetails = new StarshipDetailsViewModel
            {
                Id = starship.Id,
                Name = starship.Name,
                StarshipModel = starship.Model,
                Manufacturer = starship.Manufacturer,
                CostInCredits = starship.CostInCredits.ToString(),
                Length = starship.Length.ToString(),
                MaxAtmospheringSpeed = starship.MaxAtmospheringSpeed.ToString(),
                Crew = starship.Crew.ToString(),
                Passengers = starship.Passengers.ToString(),
                CargoCapacity = starship.CargoCapacity.ToString(),
                Consumables = starship.Consumables,
                Class = starship.Class,
                HyperdriveRating = starship.HyperdriveRating.ToString(),
                MGLT = starship.MGLT.ToString(),
                CharactersNames = charactersNames,
                MoviesNames = moviesNames
            };

            return starshipDetails;
        }

        public async Task<StarshipFormModel> GetStarshipFormByIdAsync(int id)
        {
            var starship = await _repository
                .GetEntityByIdAsync<Starship>(id);

            var starshipFormModel = new StarshipFormModel
            {
                Name = starship.Name,
                StarshipModel = starship.Model,
                Manufacturer = starship.Manufacturer,
                CostInCredits = starship.CostInCredits.ToString(),
                Length = starship.Length.ToString(),
                MaxAtmospheringSpeed = starship.MaxAtmospheringSpeed.ToString(),
                Crew = starship.Crew.ToString(),
                Passengers = starship.Passengers.ToString(),
                CargoCapacity = starship.CargoCapacity.ToString(),
                Consumables = starship.Consumables,
                Class = starship.Class,
                HyperdriveRating = starship.HyperdriveRating.ToString(),
                MGLT = starship.MGLT.ToString()
            };

            return starshipFormModel;
        }
    }
}
