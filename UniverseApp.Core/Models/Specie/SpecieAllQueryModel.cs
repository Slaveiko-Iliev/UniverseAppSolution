using System.ComponentModel.DataAnnotations;

namespace UniverseApp.Core.Models.Specie
{
    public class SpecieAllQueryModel
    {
        public const int SpeciesPerPage = 4;

        [Display(Name = "Search by character")]
        public string? SearchCharacter { get; set; } = string.Empty;

        [Display(Name = "Search by movie")]
        public string? SearchMovie { get; set; } = string.Empty;

        public int CurrentPage { get; set; } = 1;

        public int TotalSpeciesCount { get; set; }

        public IEnumerable<SpecieAllViewModel> Species { get; set; } = new List<SpecieAllViewModel>();
    }
}
