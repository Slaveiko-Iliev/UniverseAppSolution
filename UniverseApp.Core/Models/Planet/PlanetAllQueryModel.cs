using System.ComponentModel.DataAnnotations;

namespace UniverseApp.Core.Models.Planet
{
    public class PlanetAllQueryModel
    {
        public const int PlanetsPerPage = 5;

        [Display(Name = "Search by character")]
        public string? SearchCharacter { get; set; } = string.Empty;

        [Display(Name = "Search by movie")]
        public string? SearchMovie { get; set; } = string.Empty;
        
        public int CurrentPage { get; set; } = 1;

        public int TotalPlanetsCount { get; set; }

        public IEnumerable<PlanetAllViewModel> Planets { get; set; } = new List<PlanetAllViewModel>();
    }
}
