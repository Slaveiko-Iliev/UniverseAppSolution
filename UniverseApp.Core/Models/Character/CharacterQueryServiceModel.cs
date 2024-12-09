namespace UniverseApp.Core.Models.Character
{
    public class CharacterQueryServiceModel
    {
        public int TotalCharactersCount { get; set; }
        public IEnumerable<CharacterAllViewModel> Characters { get; set; } = new List<CharacterAllViewModel>();
    }
}
