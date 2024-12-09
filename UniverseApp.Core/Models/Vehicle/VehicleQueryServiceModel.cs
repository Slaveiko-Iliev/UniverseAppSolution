namespace UniverseApp.Core.Models.Vehicle
{
    public class VehicleQueryServiceModel
    {
        public int TotalVehiclesCount { get; set; }
        public IEnumerable<VehicleAllViewModel> Vehicles { get; set; } = new List<VehicleAllViewModel>();
    }
}
