using UniverseApp.Core.Models.Vehicle;

namespace UniverseApp.Core.Services.Contracts
{
	public interface IVehicleService
	{
		Task<int> AddVehicleAsync(VehicleFormModel model);

		Task<bool> ExistByIdAsync(int id);

		Task<VehicleQueryServiceModel> GetAllVehiclesAsync(string? searchCharacter, string? searchMovie, int currentPage, int vehiclesPerPage);

		Task<VehicleDetailsViewModel> GetSpecieDetailsByIdAsync(int id);
	}
}
