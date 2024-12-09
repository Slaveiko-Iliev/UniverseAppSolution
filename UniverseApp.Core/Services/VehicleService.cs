using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Models.Vehicle;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository _repository;

        public VehicleService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<VehicleQueryServiceModel> GetAllVehiclesAsync(string? searchCharacter, string? searchMovie, int currentPage, int vehiclesPerPage)
        {
            var vehicles = _repository
                .AllReadOnly<Vehicle>();

            if (!string.IsNullOrEmpty(searchCharacter))
            {
                vehicles = vehicles
                    .Where(v => v.Characters.Any(ch => ch.Name == searchCharacter));
            }

            if (!string.IsNullOrEmpty(searchMovie))
            {
                vehicles = vehicles
                    .Where(v => v.Movies.Any(m => m.Title == searchMovie));
            }

            var totalVehiclesCount = await vehicles.CountAsync();

            vehicles = vehicles
                .OrderBy(m => m.Id)
                .Skip((currentPage - 1) * vehiclesPerPage)
                .Take(vehiclesPerPage);

            var vehicleViewModels = await vehicles
                .Select(m => new VehicleAllViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Model = m.Model,
                    Manufacturer = m.Manufacturer,
                    CostInCredits = m.CostInCredits.ToString(),
                    Length = m.Length.ToString(),
                    MaxAtmospheringSpeed = m.MaxAtmospheringSpeed.ToString(),
                    Crew = m.Crew.ToString(),
                    Passengers = m.Passengers.ToString(),
                    CargoCapacity = m.CargoCapacity.ToString(),
                    Consumables = m.Consumables,
                    Class = m.Class
                })
                .ToListAsync();

            var vehicleAllQueryModels = new VehicleQueryServiceModel()
            {
                TotalVehiclesCount = totalVehiclesCount,
                Vehicles = vehicleViewModels
            };

            return vehicleAllQueryModels;
        }
    }
}
