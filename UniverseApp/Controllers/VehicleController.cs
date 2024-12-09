using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Models.Vehicle;
using UniverseApp.Core.Services.Contracts;

namespace UniverseApp.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<IActionResult> All([FromQuery] VehicleAllQueryModel model)
        {
            VehicleQueryServiceModel queryResult = await _vehicleService.GetAllVehiclesAsync(model.SearchCharacter, model.SearchMovie, model.CurrentPage, VehicleAllQueryModel.VehiclesPerPage);

            model.Vehicles = queryResult.Vehicles;
            model.TotalVehiclesCount = queryResult.TotalVehiclesCount;

            return View(model);
        }
    }
}
