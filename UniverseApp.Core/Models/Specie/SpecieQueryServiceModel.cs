namespace UniverseApp.Core.Models.Specie
{
    public class SpecieQueryServiceModel
    {
        public int TotalSpeciesCount { get; set; }
        public IEnumerable<SpecieAllViewModel> Species { get; set; } = new List<SpecieAllViewModel>();
    }
}
