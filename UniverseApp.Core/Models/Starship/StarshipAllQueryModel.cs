using System.ComponentModel.DataAnnotations;

namespace UniverseApp.Core.Models.Starship
{
    public class StarshipAllQueryModel
    {
        public const int StarshipsPerPage = 4;

        [Display(Name = "Search by character")]
        public string? SearchCharacter { get; set; } = string.Empty;

        [Display(Name = "Search by movie")]
        public string? SearchMovie { get; set; } = string.Empty;

        public int CurrentPage { get; set; } = 1;

        public int TotalStarshipsCount { get; set; }

        public IEnumerable<StarshipAllViewModel> Starships { get; set; } = new List<StarshipAllViewModel>();
    }
}
