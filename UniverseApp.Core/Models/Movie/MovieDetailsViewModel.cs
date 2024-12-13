using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Core.Models.Movie
{
	public class MovieDetailsViewModel : MovieFormModel
	{
		public int Id { get; set; }

		public ICollection<KeyValuePair<string, EntityNameDto>> CharactersNames { get; set; } = new List<KeyValuePair<string, EntityNameDto>>();

		public ICollection<KeyValuePair<string, EntityNameDto>> PlanetsNames { get; set; } = new List<KeyValuePair<string, EntityNameDto>>();

		public ICollection<KeyValuePair<string, EntityNameDto>> StarshipsNames { get; set; } = new List<KeyValuePair<string, EntityNameDto>>();

		public ICollection<KeyValuePair<string, EntityNameDto>> VehiclesNames { get; set; } = new List<KeyValuePair<string, EntityNameDto>>();

		public ICollection<KeyValuePair<string, EntityNameDto>> SpeciesNames { get; set; } = new List<KeyValuePair<string, EntityNameDto>>();
	}
}
