namespace UniverseApp.Core.Models.Movie
{
    public class MovieQueryServiceModel
    {
        public int TotalMoviesCount { get; set; }
        public IEnumerable<MovieAllViewModel> Movies { get; set; } = new List<MovieAllViewModel>();
    }
}
