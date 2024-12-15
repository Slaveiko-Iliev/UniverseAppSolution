namespace UniverseApp.Core.Models.Movie
{
	public class MovieDeleteViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Director { get; set; } = null!;

		public string ReleaseDate { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;
	}
}
