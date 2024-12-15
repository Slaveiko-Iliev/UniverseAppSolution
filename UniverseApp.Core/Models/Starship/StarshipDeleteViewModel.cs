namespace UniverseApp.Core.Models.Starship
{
    public class StarshipDeleteViewModel
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? StarshipModel { get; set; }

        public string? Manufacturer { get; set; }


        public string? StarshipClass { get; set; }
    }
}
