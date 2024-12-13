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

		public CharacterService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<CharacterQueryServiceModel> GetAllCharactersAsync(string? searchMovie, string? searchSpecie, string? searchVehicle, string? searchStarship, int currentPage, int charactersPerPage)
		{
			var characters = _repository
				.AllReadOnly<Character>();

			if (!string.IsNullOrEmpty(searchMovie))
			{
				characters = characters
					.Where(ch => ch.Movies.Any(m => m.Title == searchMovie));
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
	}
}
