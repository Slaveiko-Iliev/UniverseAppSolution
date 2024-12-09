namespace UniverseApp.Core.Models.Starship
{
    public class StarshipQueryServiceModel
    {
        public int TotalStarshipsCount { get; set; }

        public IEnumerable<StarshipAllViewModel> Starships { get; set; } = new List<StarshipAllViewModel>();

    }
}
