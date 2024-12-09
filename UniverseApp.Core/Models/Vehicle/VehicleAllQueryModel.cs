using System.ComponentModel.DataAnnotations;

namespace UniverseApp.Core.Models.Vehicle
{
    public class VehicleAllQueryModel
    {
        public const int VehiclesPerPage = 4;

        [Display(Name = "Search by character")]
        public string? SearchCharacter { get; set; } = string.Empty;

        [Display(Name = "Search by movie")]
        public string? SearchMovie { get; set; } = string.Empty;

        public int CurrentPage { get; set; } = 1;

        public int TotalVehiclesCount { get; set; }

        public IEnumerable<VehicleAllViewModel> Vehicles { get; set; } = new List<VehicleAllViewModel>();
    }
}
