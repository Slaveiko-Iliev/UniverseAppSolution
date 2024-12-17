using MockQueryable;
using Moq;
using UniverseApp.Core.Models.Vehicle;
using UniverseApp.Core.Services;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Tests
{
    internal class VehicleServiceTests
    {
        private Mock<IRepository> _repositoryMock;
        private Mock<IServiceHelper> _serviceHelperMock;
        private VehicleService _vehicleService;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository>();
            _serviceHelperMock = new Mock<IServiceHelper>();
            _vehicleService = new VehicleService(_repositoryMock.Object, _serviceHelperMock.Object);
        }

        [Test]
        public async Task AddVehicleAsync_ShouldAddVehicle()
        {
            // Arrange
            var model = new VehicleFormModel
            {
                Name = "Test Vehicle",
                VehicleModel = "Model X",
                Manufacturer = "Test Manufacturer",
                CostInCredits = "1000",
                Length = "10.5",
                MaxAtmospheringSpeed = "500",
                Crew = "5",
                Passengers = "10",
                CargoCapacity = "1000",
                Consumables = "1 year",
                Class = "Class A"
            };

            _serviceHelperMock.Setup(x => x.TryParseInputToInt(It.IsAny<string>())).Returns(1000);
            _serviceHelperMock.Setup(x => x.TryParseInputToDouble(It.IsAny<string>())).Returns(10.5);

            _repositoryMock.Setup(x => x.AllReadOnly<Vehicle>()).Returns(new List<Vehicle>().AsQueryable());
            _repositoryMock.Setup(x => x.AddAsync(It.IsAny<Vehicle>())).Returns(Task.CompletedTask);
            _repositoryMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _vehicleService.AddVehicleAsync(model);

            // Assert
            _repositoryMock.Verify(x => x.AddAsync(It.IsAny<Vehicle>()), Times.Once);
            _repositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            Assert.That(result, Is.EqualTo(38));
        }

        [Test]
        public async Task DeleteVehicleAsync_ShouldMarkVehicleAsDeleted()
        {

            // Arrange
            var vehicle = new Vehicle { Id = 1, Name = "TestVehicle", IsDeleted = false };

            var vehicles = new List<Vehicle>()
            {
              new Vehicle{ Id = 1, IsDeleted = false }
            }.AsQueryable();
            var mock = vehicles.BuildMock();

            _repositoryMock.Setup(x => x.All<Vehicle>()).Returns(mock);
            _repositoryMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            await _vehicleService.DeleteVehicleAsync(1);

            // Assert
            Assert.IsTrue(vehicles.Where(v => v.Id == 1).Any(v => v.IsDeleted));
            _repositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task EditVehicleAsync_ShouldEditVehicle()
        {
            // Arrange
            var vehicle = new Vehicle { Id = 1 };
            var model = new VehicleFormModel
            {
                Name = "Updated Vehicle",
                VehicleModel = "Updated Model",
                Manufacturer = "Updated Manufacturer",
                CostInCredits = "2000",
                Length = "20.5",
                MaxAtmospheringSpeed = "2000",
                Crew = "10",
                Passengers = "20",
                CargoCapacity = "2000",
                Consumables = "2 years",
                Class = "Class B"
            };

            _repositoryMock.Setup(x => x.GetEntityByIdAsync<Vehicle>(1)).ReturnsAsync(vehicle);
            _serviceHelperMock.Setup(x => x.TryParseInputToInt(It.IsAny<string>())).Returns(600);
            _serviceHelperMock.Setup(x => x.TryParseInputToDouble(It.IsAny<string>())).Returns(20.5);
            _repositoryMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            await _vehicleService.EditVehicleAsync(1, model);

            // Assert
            Assert.That(vehicle.Name, Is.EqualTo("Updated Vehicle"));
            Assert.That(vehicle.Model, Is.EqualTo("Updated Model"));
            Assert.That(vehicle.Manufacturer, Is.EqualTo("Updated Manufacturer"));
            Assert.That(vehicle.CostInCredits, Is.EqualTo(600));
            Assert.That(vehicle.Length, Is.EqualTo(20.5));
            Assert.That(vehicle.MaxAtmospheringSpeed, Is.EqualTo(600));
            Assert.That(vehicle.Crew, Is.EqualTo(600));
            Assert.That(vehicle.Passengers, Is.EqualTo(600));
            Assert.That(vehicle.CargoCapacity, Is.EqualTo(600));
            Assert.That(vehicle.Consumables, Is.EqualTo("2 years"));
            Assert.That(vehicle.Class, Is.EqualTo("Class B"));
            _repositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task ExistByIdAsync_ShouldReturnTrueIfExists()
        {
            // Arrange
            var vehicles = new List<Vehicle>()
            {
              new Vehicle{ Id = 1, IsDeleted = false }
            };
            var mock = vehicles.BuildMock();

            _repositoryMock.Setup(x => x.AllReadOnly<Vehicle>()).Returns(mock);

            // Act
            var result = await _vehicleService.ExistByIdAsync(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetAllVehiclesAsync_ShouldReturnVehicles()
        {
            // Arrange
            var vehicles = new List<Vehicle>()
            {
                new Vehicle { Id = 1, Name = "Vehicle 1", IsDeleted = false },
                new Vehicle { Id = 2, Name = "Vehicle 2", IsDeleted = false }
            };
            var mock = vehicles.BuildMock();

            _repositoryMock.Setup(x => x.AllReadOnly<Vehicle>()).Returns(mock);

            // Act
            var result = await _vehicleService.GetAllVehiclesAsync(null, null, 1, 10);

            // Assert
            Assert.That(result.TotalVehiclesCount, Is.EqualTo(2));
            Assert.That(result.Vehicles.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetVehicleDeleteModelByIdAsync_ShouldReturnVehicleDeleteModel()
        {
            // Arrange
            var vehicle = new Vehicle { Id = 1, Name = "Vehicle 1", Model = "Model 1", Manufacturer = "Manufacturer 1", Class = "Class 1" };
            _repositoryMock.Setup(x => x.GetEntityByIdAsync<Vehicle>(1)).ReturnsAsync(vehicle);

            // Act
            var result = await _vehicleService.GetVehicleDeleteModelByIdAsync(1);

            // Assert
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Vehicle 1"));
            Assert.That(result.VehicleModel, Is.EqualTo("Model 1"));
            Assert.That(result.Manufacturer, Is.EqualTo("Manufacturer 1"));
            Assert.That(result.Class, Is.EqualTo("Class 1"));
        }

        [Test]
        public async Task GetVehicleFormByIdAsync_ShouldReturnVehicleFormModel()
        {
            // Arrange
            var vehicle = new Vehicle { Id = 1, Name = "Vehicle 1", Model = "Model 1", Manufacturer = "Manufacturer 1", CostInCredits = 1000, Length = 10.5, MaxAtmospheringSpeed = 500, Crew = 5, Passengers = 10, CargoCapacity = 1000, Consumables = "1 year", Class = "Class 1" };
            _repositoryMock.Setup(x => x.GetEntityByIdAsync<Vehicle>(1)).ReturnsAsync(vehicle);

            // Act
            var result = await _vehicleService.GetVehicleFormByIdAsync(1);

            // Assert
            Assert.That(result.Name, Is.EqualTo("Vehicle 1"));
            Assert.That(result.VehicleModel, Is.EqualTo("Model 1"));
            Assert.That(result.Manufacturer, Is.EqualTo("Manufacturer 1"));
            Assert.That(result.CostInCredits, Is.EqualTo("1000"));
            Assert.That(result.Length, Is.EqualTo("10.5"));
            Assert.That(result.MaxAtmospheringSpeed, Is.EqualTo("500"));
            Assert.That(result.Crew, Is.EqualTo("5"));
            Assert.That(result.Passengers, Is.EqualTo("10"));
            Assert.That(result.CargoCapacity, Is.EqualTo("1000"));
            Assert.That(result.Consumables, Is.EqualTo("1 year"));
            Assert.That(result.Class, Is.EqualTo("Class 1"));
        }
    }
}
