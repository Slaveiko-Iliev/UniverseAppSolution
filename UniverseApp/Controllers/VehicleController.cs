using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Models.Vehicle;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Constants.JediConstants;

namespace UniverseApp.Controllers
{
	public class VehicleController : BaseController
	{
		private readonly IVehicleService _vehicleService;

		public VehicleController(IVehicleService vehicleService)
		{
			_vehicleService = vehicleService;
		}

		[HttpGet]
		public IActionResult Add()
		{
			if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
			{
				return Unauthorized();
			}

			var model = new VehicleFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(VehicleFormModel model)
		{
			if (!User.IsInRole(PadawanRoleName) && !User.IsInRole(YodaRoleName))
			{
				return Unauthorized();
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			int newVehicleId = await _vehicleService.AddVehicleAsync(model);

			return RedirectToAction(nameof(Details), new { id = newVehicleId });
		}

		public async Task<IActionResult> All([FromQuery] VehicleAllQueryModel model)
		{
			VehicleQueryServiceModel queryResult = await _vehicleService.GetAllVehiclesAsync(model.SearchCharacter, model.SearchMovie, model.CurrentPage, VehicleAllQueryModel.VehiclesPerPage);

			model.Vehicles = queryResult.Vehicles;
			model.TotalVehiclesCount = queryResult.TotalVehiclesCount;

			return View(model);
		}

		[CheckIsDeleted<Vehicle>]
		public async Task<IActionResult> Details(int id)
		{
			if (await _vehicleService.ExistByIdAsync(id) == false)
			{
				return BadRequest();
			}

			var model = await _vehicleService.GetSpecieDetailsByIdAsync(id);

			return View(model);
		}
	}
}
