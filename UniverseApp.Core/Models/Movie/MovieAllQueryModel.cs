using System.ComponentModel.DataAnnotations;

namespace UniverseApp.Core.Models.Movie
{
	public class MovieAllQueryModel
	{
		public const int MoviesPerPage = 3;

		[Display(Name = "Search by character")]
		public string? SearchCharacter { get; set; } = string.Empty;

		[Display(Name = "Search by planet")]
		public string? SearchPlanet { get; set; } = string.Empty;

		[Display(Name = "Search by specie")]
		public string? SearchSpecie { get; set; } = string.Empty;

		[Display(Name = "Search by vehicle")]
		public string? SearchVehicle { get; set; } = string.Empty;

		[Display(Name = "Search by starship")]
		public string? SearchStarship { get; set; } = string.Empty;

		public int CurrentPage { get; set; } = 1;

		public int TotalMoviesCount { get; set; }

		public IEnumerable<MovieAllViewModel> Movies { get; set; } = new List<MovieAllViewModel>();
	}
}
