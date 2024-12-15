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
        private readonly IServiceHelper _serviceHelper;

        public VehicleService(IRepository repository, IServiceHelper serviceHelper)
        {
            _repository = repository;
            _serviceHelper = serviceHelper;
        }

        public async Task<int> AddVehicleAsync(VehicleFormModel model)
        {
            int? costInCredits = model.CostInCredits != null
                ? _serviceHelper.TryParseInputToInt(model.CostInCredits)
                : null;
            double? length = model.Length != null
                ? _serviceHelper.TryParseInputToDouble(model.Length)
                : null;
            int? maxAtmospheringSpeed = model.MaxAtmospheringSpeed != null
                ? _serviceHelper.TryParseInputToInt(model.MaxAtmospheringSpeed)
                : null;
            int? crew = model.Crew != null
                ? _serviceHelper.TryParseInputToInt(model.Crew)
                : null;
            int? passengers = model.Passengers != null
                ? _serviceHelper.TryParseInputToInt(model.Passengers)
                : null;
            int? cargoCapacity = model.CargoCapacity != null
                ? _serviceHelper.TryParseInputToInt(model.CargoCapacity)
                : null;

            var newVehicle = new Vehicle()
            {
                Id = _repository.AllReadOnly<Vehicle>().Count() + 38,
                Name = model.Name,
                Model = model.VehicleModel,
                Manufacturer = model.Manufacturer,
                CostInCredits = costInCredits,
                Length = length,
                MaxAtmospheringSpeed = maxAtmospheringSpeed,
                Crew = crew,
                Passengers = passengers,
                CargoCapacity = cargoCapacity,
                Consumables = model.Consumables,
                Class = model.Class
            };

            await _repository.AddAsync(newVehicle);
            await _repository.SaveChangesAsync();

            return newVehicle.Id;
        }

        public async Task DeleteVehicleAsync(int id)
        {
            var vehicle = await _repository
                .All<Vehicle>()
                .FirstAsync(m => m.Id == id);

            vehicle.IsDeleted = true;
            await _repository.SaveChangesAsync();
        }

        public async Task EditVehicleAsync(int id, VehicleFormModel model)
        {
            var vehicle = await _repository
                .GetEntityByIdAsync<Vehicle>(id);

            vehicle.Name = model.Name;
            vehicle.Model = model.VehicleModel;
            vehicle.Manufacturer = model.Manufacturer;
            vehicle.CostInCredits = model.CostInCredits != null
                ? _serviceHelper.TryParseInputToInt(model.CostInCredits)
                : null;
            vehicle.Length = model.Length != null
                ? _serviceHelper.TryParseInputToDouble(model.Length)
                : null;
            vehicle.MaxAtmospheringSpeed = model.MaxAtmospheringSpeed != null
                ? _serviceHelper.TryParseInputToInt(model.MaxAtmospheringSpeed)
                : null;
            vehicle.Crew = model.Crew != null
                ? _serviceHelper.TryParseInputToInt(model.Crew)
                : null;
            vehicle.Passengers = model.Passengers != null
                ? _serviceHelper.TryParseInputToInt(model.Passengers)
                : null;
            vehicle.CargoCapacity = model.CargoCapacity != null
                ? _serviceHelper.TryParseInputToInt(model.CargoCapacity)
                : null;
            vehicle.Consumables = model.Consumables;
            vehicle.Class = model.Class;

            await _repository.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(int id) =>
            await _repository
                .AllReadOnly<Vehicle>()
                .Where(m => !m.IsDeleted)
                .AnyAsync(m => m.Id == id);

        public async Task<VehicleQueryServiceModel> GetAllVehiclesAsync(string? searchCharacter, string? searchMovie, int currentPage, int vehiclesPerPage)
        {
            var vehicles = _repository
                .AllReadOnly<Vehicle>()
                .Where(v => !v.IsDeleted);

            if (!string.IsNullOrEmpty(searchCharacter))
            {
                vehicles = vehicles
                    .Where(v => v.Characters.Any(ch => ch.Name == searchCharacter));
            }

            if (!string.IsNullOrEmpty(searchMovie))
            {
                vehicles = vehicles
                    .Where(v => v.Movies.Any(m => m.Name == searchMovie));
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
                    VehicleModel = m.Model,
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

        public async Task<VehicleDeleteViewModel> GetVehicleDeleteModelByIdAsync(int id)
        {
            var vehicle = await _repository
                .GetEntityByIdAsync<Vehicle>(id);

            var vehicleDeleteModel = new VehicleDeleteViewModel
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                VehicleModel = vehicle.Model,
                Manufacturer = vehicle.Manufacturer,
                Class = vehicle.Class
            };

            return vehicleDeleteModel;
        }

        public async Task<VehicleDetailsViewModel> GetVehicleDetailsByIdAsync(int id)
        {
            var vehicle = await _repository
                .GetEntityByIdAsync<Vehicle>(id);

            var charactersNames = await _repository.GetEntitiesNames<Character>(vehicle.Characters);
            var moviesNames = await _repository.GetEntitiesNames<Movie>(vehicle.Movies);

            var vehicleDetails = new VehicleDetailsViewModel
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                VehicleModel = vehicle.Model,
                Manufacturer = vehicle.Manufacturer,
                CostInCredits = vehicle.CostInCredits.ToString(),
                Length = vehicle.Length.ToString(),
                MaxAtmospheringSpeed = vehicle.MaxAtmospheringSpeed.ToString(),
                Crew = vehicle.Crew.ToString(),
                Passengers = vehicle.Passengers.ToString(),
                CargoCapacity = vehicle.CargoCapacity.ToString(),
                Consumables = vehicle.Consumables,
                Class = vehicle.Class,
                CharactersNames = charactersNames,
                MoviesNames = moviesNames
            };

            return vehicleDetails;
        }

        public async Task<VehicleFormModel> GetVehicleFormByIdAsync(int id)
        {
            var starship = await _repository
                .GetEntityByIdAsync<Vehicle>(id);

            var vehicleFormModel = new VehicleFormModel
            {
                Name = starship.Name,
                VehicleModel = starship.Model,
                Manufacturer = starship.Manufacturer,
                CostInCredits = starship.CostInCredits.ToString(),
                Length = starship.Length.ToString(),
                MaxAtmospheringSpeed = starship.MaxAtmospheringSpeed.ToString(),
                Crew = starship.Crew.ToString(),
                Passengers = starship.Passengers.ToString(),
                CargoCapacity = starship.CargoCapacity.ToString(),
                Consumables = starship.Consumables,
                Class = starship.Class
            };

            return vehicleFormModel;
        }
    }
}
