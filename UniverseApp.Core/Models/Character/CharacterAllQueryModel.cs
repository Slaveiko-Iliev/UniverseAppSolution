using System.ComponentModel.DataAnnotations;

namespace UniverseApp.Core.Models.Character
{
    public class CharacterAllQueryModel
    {
        public const int CharactersPerPage = 4;

        [Display(Name = "Search by movie")]
        public string? SearchMovie { get; set; } = string.Empty;

        [Display(Name = "Search by specie")]
        public string? SearchSpecie { get; set; } = string.Empty;

        [Display(Name = "Search by vehicle")]
        public string? SearchVehicle { get; set; } = string.Empty;

        [Display(Name = "Search by starship")]
        public string? SearchStarship { get; set; } = string.Empty;

        public int CurrentPage { get; set; } = 1;

        public int TotalCharactersCount { get; set; }

        public IEnumerable<CharacterAllViewModel> Characters { get; set; } = new List<CharacterAllViewModel>();
    }
}
