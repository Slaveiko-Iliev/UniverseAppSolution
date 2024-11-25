namespace UniverseApp.Core.Models.Movie
{
	public class MovieDetailsViewModel : MovieFormModel
	{
		public int Id { get; set; }

		public ICollection<string> CharactersNames { get; set; } = new List<string>();

		public ICollection<string> PlanetsNames { get; set; } = new List<string>();

		public ICollection<string> StarshipsNames { get; set; } = new List<string>();

		public ICollection<string> VehiclesNames { get; set; } = new List<string>();

		public ICollection<string> SpeciesNames { get; set; } = new List<string>();
	}
}
