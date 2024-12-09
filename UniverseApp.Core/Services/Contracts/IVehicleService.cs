using UniverseApp.Core.Models.Vehicle;

namespace UniverseApp.Core.Services.Contracts
{
    public interface IVehicleService
    {
        Task<VehicleQueryServiceModel> GetAllVehiclesAsync(string? searchCharacter, string? searchMovie, int currentPage, int vehiclesPerPage);
    }
}
