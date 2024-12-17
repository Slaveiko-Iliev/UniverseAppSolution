using UniverseApp.Core.Models.Vehicle;
using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Core.Services.Contracts
{
	public interface IVehicleService
	{
		Task<int> AddVehicleAsync(VehicleFormModel model);
        Task AddVehiclesRangeAsync(List<VehicleInfoDto> vehiclesDtoList);
        Task DeleteVehicleAsync(int id);
        Task EditVehicleAsync(int id, VehicleFormModel model);
		Task<bool> ExistByIdAsync(int id);

		Task<VehicleQueryServiceModel> GetAllVehiclesAsync(string? searchCharacter, string? searchMovie, int currentPage, int vehiclesPerPage);
        Task<VehicleDeleteViewModel> GetVehicleDeleteModelByIdAsync(int id);
        Task<VehicleDetailsViewModel> GetVehicleDetailsByIdAsync(int id);
		Task<VehicleFormModel> GetVehicleFormByIdAsync(int id);
	}
}
