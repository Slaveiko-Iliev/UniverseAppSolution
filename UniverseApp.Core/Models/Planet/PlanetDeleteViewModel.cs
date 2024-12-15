namespace UniverseApp.Core.Models.Planet
{
    public class PlanetDeleteViewModel
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? RotationPeriod { get; set; }

        public string? OrbitalPeriod { get; set; }

        public string? Population { get; set; }
    }
}
