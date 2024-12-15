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

		public async Task<bool> ExistByIdAsync(int id) =>
			await _repository
				.AllReadOnly<Starship>()
				.Where(m => !m.IsDeleted)
				.AnyAsync(m => m.Id == id);

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

		public async Task<StarshipDetailsViewModel> GetSpecieDetailsByIdAsync(int id)
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
	}
}
