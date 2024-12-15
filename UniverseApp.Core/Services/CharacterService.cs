using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Models.Character;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services
{
	public class CharacterService : ICharacterService
	{
		private readonly IRepository _repository;
		private readonly IServiceHelper _serviceHelper;

		public CharacterService(IRepository repository, IServiceHelper serviceHelper)
		{
			_repository = repository;
			_serviceHelper = serviceHelper;
		}

		public async Task<int> AddCharacterAsync(CharacterFormModel model)
		{
			int? height = model.Height != null
				? _serviceHelper.TryParseInputToInt(model.Height)
				: null;
			int? mass = model.Mass != null
				? _serviceHelper.TryParseInputToInt(model.Mass)
				: null;

			var newCharacter = new Character()
			{
				Id = _repository.AllReadOnly<Character>().Count() + 2,
				Name = model.Name,
				Height = height,
				Mass = mass,
				HairColor = model.HairColor,
				SkinColor = model.SkinColor,
				EyeColor = model.EyeColor,
				BirthYear = model.BirthYear,
				Gender = model.Gender,
			};

			await _repository.AddAsync(newCharacter);
			await _repository.SaveChangesAsync();

			return newCharacter.Id;
		}

		public async Task EditCharacterAsync(int id, CharacterFormModel model)
		{
			var character = await _repository
				.GetEntityByIdAsync<Character>(id);

			character.Name = model.Name;
			character.Height = model.Height != null
				? _serviceHelper.TryParseInputToInt(model.Height)
				: null;
			character.Mass = model.Mass != null
				? _serviceHelper.TryParseInputToInt(model.Mass)
				: null;
			character.HairColor = model.HairColor;
			character.SkinColor = model.SkinColor;
			character.EyeColor = model.EyeColor;
			character.BirthYear = model.BirthYear;
			character.Gender = model.Gender;

			await _repository.SaveChangesAsync();
		}

		public async Task<bool> ExistByIdAsync(int id) =>
			await _repository
				.AllReadOnly<Character>()
				.Where(m => !m.IsDeleted)
				.AnyAsync(m => m.Id == id);

		public async Task<CharacterQueryServiceModel> GetAllCharactersAsync(string? searchMovie, string? searchSpecie, string? searchVehicle, string? searchStarship, int currentPage, int charactersPerPage)
		{
			var characters = _repository
				.AllReadOnly<Character>();

			if (!string.IsNullOrEmpty(searchMovie))
			{
				characters = characters
					.Where(ch => ch.Movies.Any(m => m.Name == searchMovie));
			}

			if (!string.IsNullOrEmpty(searchSpecie))
			{
				characters = characters
					.Where(ch => ch.Species.Any(sp => sp.Name == searchSpecie));
			}

			if (!string.IsNullOrEmpty(searchVehicle))
			{
				characters = characters
					.Where(ch => ch.Vehicles.Any(v => v.Name == searchVehicle));
			}

			if (!string.IsNullOrEmpty(searchStarship))
			{
				characters = characters
					.Where(ch => ch.Starships.Any(st => st.Name == searchStarship));
			}

			int totalCharactersCount = await characters.CountAsync();

			characters = characters
				.OrderBy(m => m.Id)
				.Skip((currentPage - 1) * charactersPerPage)
				.Take(charactersPerPage);

			var charactersViewModels = await characters
				.Select(ch => new CharacterAllViewModel
				{
					Id = ch.Id,
					Name = ch.Name,
					Height = ch.Height.ToString(),
					Mass = ch.Mass.ToString(),
					HairColor = ch.HairColor,
					SkinColor = ch.SkinColor,
					EyeColor = ch.EyeColor,
					BirthYear = ch.BirthYear,
					Gender = ch.Gender,
					PlanetId = ch.PlanetId,
					Planet = ch.Planet
				})
				.ToListAsync();

			var characterAllQueryModels = new CharacterQueryServiceModel()
			{
				TotalCharactersCount = totalCharactersCount,
				Characters = charactersViewModels
			};

			return characterAllQueryModels;
		}

		public async Task<CharacterDetailsViewModel> GetCharacterDetailsByIdAsync(int id)
		{
			var character = await _repository
				.GetEntityByIdAsync<Character>(id);

			var moviesNames = await _repository.GetEntitiesNames<Movie>(character.Movies);
			var speciesNames = await _repository.GetEntitiesNames<Specie>(character.Species);
			var vehiclesNames = await _repository.GetEntitiesNames<Vehicle>(character.Vehicles);
			var starshipsNames = await _repository.GetEntitiesNames<Starship>(character.Starships);

			var characterDetails = new CharacterDetailsViewModel
			{
				Id = character.Id,
				Name = character.Name,
				Height = character.Height.ToString(),
				Mass = character.Mass.ToString(),
				HairColor = character.HairColor,
				SkinColor = character.SkinColor,
				EyeColor = character.EyeColor,
				BirthYear = character.BirthYear,
				Gender = character.Gender,
				MoviesNames = moviesNames,
				SpeciesNames = speciesNames,
				VehiclesNames = vehiclesNames,
				StarshipsNames = starshipsNames
			};

			return characterDetails;
		}

		public async Task<CharacterFormModel> GetCharacterFormByIdAsync(int id)
		{
			var character = await _repository
				.GetEntityByIdAsync<Character>(id);

			var characterFormModel = new CharacterFormModel
			{
				Name = character.Name,
				Height = character.Height.ToString(),
				Mass = character.Mass.ToString(),
				HairColor = character.HairColor,
				SkinColor = character.SkinColor,
				EyeColor = character.EyeColor,
				BirthYear = character.BirthYear,
				Gender = character.Gender,
			};

			return characterFormModel;
		}
	}
}
