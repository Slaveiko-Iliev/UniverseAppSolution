namespace UniverseApp.Core.Models.Planet
{
    public class PlanetQueryServiceModel
    {
        public int TotalPlanetsCount { get; set; }
        public IEnumerable<PlanetAllViewModel> Planets { get; set; } = new List<PlanetAllViewModel>();
    }
}
