namespace UniverseApp.Core.Models.Vehicle
{
    public class VehicleDeleteViewModel
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? VehicleModel { get; set; }

        public string? Manufacturer { get; set; }

        public string? Class { get; set; }
    }
}
