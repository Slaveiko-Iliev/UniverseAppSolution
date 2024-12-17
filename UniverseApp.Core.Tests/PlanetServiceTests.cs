using MockQueryable;
using Moq;
using UniverseApp.Core.Models.Planet;
using UniverseApp.Core.Services;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Tests
{
    internal class PlanetServiceTests
    {
        private Mock<IRepository> _repositoryMock;
        private Mock<IServiceHelper> _serviceHelperMock;
        private PlanetService _planetService;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository>();
            _serviceHelperMock = new Mock<IServiceHelper>();
            _planetService = new PlanetService(_repositoryMock.Object, _serviceHelperMock.Object);
        }

        [Test]
        public async Task AddPlanetAsync_ShouldAddPlanet()
        {
            // Arrange
            var model = new PlanetFormModel
            {
                Name = "Earth",
                RotationPeriod = "24",
                OrbitalPeriod = "365",
                Climate = "Temperate",
                Gravity = "1g",
                Terrain = "Various",
                SurfaceWater = "70",
                Population = "70000000"
            };

            _repositoryMock.Setup(r => r.AllReadOnly<Planet>()).Returns(new List<Planet>().AsQueryable());
            _serviceHelperMock.Setup(s => s.SplitInput(It.IsAny<string>())).Returns(new string[] { "Temperate" });
            _serviceHelperMock.Setup(s => s.GetParsedIds(It.IsAny<string>())).Returns(new int[] { 1, 2, 3 });
            _serviceHelperMock.Setup(s => s.GetEntitiesByIds<Character>(It.IsAny<int[]>())).ReturnsAsync(new List<Character>());
            _serviceHelperMock.Setup(s => s.GetEntitiesByIds<Movie>(It.IsAny<int[]>())).ReturnsAsync(new List<Movie>());

            // Act
            var result = await _planetService.AddPlanetAsync(model);

            // Assert
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Planet>()), Times.Once);
            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task DeletePlanetAsync_ShouldMarkPlanetAsDeleted()
        {
            // Arrange
            var planets = new List<Planet>
            {
                new Planet { Id = 1, Name = "TastPlanet", IsDeleted = false }
            };

            var mock = planets.AsQueryable().BuildMock();

            _repositoryMock.Setup(r => r.All<Planet>()).Returns(mock);
            _repositoryMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            await _planetService.DeletePlanetAsync(1);

            // Assert
            Assert.IsTrue(planets.Where(v => v.Id == 1).Any(v => v.IsDeleted));
            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task EditPlanetAsync_ShouldEditPlanet()
        {
            // Arrange
            var model = new PlanetFormModel
            {
                Name = "Mars",
                RotationPeriod = "25",
                OrbitalPeriod = "25",
                Climate = "Arid",
                Gravity = "0.38g",
                Terrain = "Desert",
                SurfaceWater = "0",
                Population = "0"
            };

            var planet = new Planet { Id = 1, Name = "Earth", RotationPeriod = 687, OrbitalPeriod = 687, Climate = "Desert", SurfaceWater = 0.8 };

            _repositoryMock.Setup(r => r.GetEntityByIdAsync<Planet>(1)).ReturnsAsync(planet);
            _serviceHelperMock.Setup(s => s.TryParseInputToInt(It.IsAny<string>())).Returns(25);
            _serviceHelperMock.Setup(s => s.TryParseInputToDouble(It.IsAny<string>())).Returns(0.0);

            // Act
            await _planetService.EditPlanetAsync(1, model);

            // Assert
            Assert.That(planet.Name, Is.EqualTo("Mars"));
            Assert.That(planet.RotationPeriod, Is.EqualTo(25));
            Assert.That(planet.OrbitalPeriod, Is.EqualTo(25));
            Assert.That(planet.Gravity, Is.EqualTo("0.38g"));
            Assert.That(planet.SurfaceWater, Is.EqualTo(0.0));

            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task ExistByIdAsync_ShouldReturnTrueIfExists()
        {
            // Arrange
            var planets = new List<Planet> { new Planet { Id = 1, Name = "TestPlanet", IsDeleted = false } }.AsQueryable();

            var mock = planets.BuildMock();

            _repositoryMock.Setup(x => x.AllReadOnly<Planet>()).Returns(mock);

            // Act
            var result = await _planetService.ExistByIdAsync(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetAllPlanetsAsync_ShouldReturnPlanets()
        {
            // Arrange
            var planets = new List<Planet>
                {
                    new Planet { Id = 1, Name = "Earth", IsDeleted = false },
                    new Planet { Id = 2, Name = "Mars", IsDeleted = false }
                }.AsQueryable();

            var mock = planets.BuildMock();

            _repositoryMock.Setup(x => x.AllReadOnly<Planet>()).Returns(mock);

            // Act
            var result = await _planetService.GetAllPlanetsAsync(null, null, 1, 10);

            // Assert
            Assert.That(result.TotalPlanetsCount, Is.EqualTo(2));
            Assert.That(result.Planets.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetPlanetDeleteModelByIdAsync_ShouldReturnPlanetDeleteModel()
        {
            // Arrange
            var planet = new Planet { Id = 1, Name = "Earth", RotationPeriod = 24, OrbitalPeriod = 365, Population = 70000000 };
            _repositoryMock.Setup(r => r.GetEntityByIdAsync<Planet>(1)).ReturnsAsync(planet);

            // Act
            var result = await _planetService.GetPlanetDeleteModelByIdAsync(1);

            // Assert
            Assert.That(result.Name, Is.EqualTo("Earth"));
            Assert.That(result.RotationPeriod, Is.EqualTo("24"));
            Assert.That(result.OrbitalPeriod, Is.EqualTo("365"));
            Assert.That(result.Population, Is.EqualTo("70000000"));
        }

        [Test]
        public async Task GetPlanetFormByIdAsync_ShouldReturnPlanetFormModel()
        {
            // Arrange
            var planet = new Planet { Id = 1, Name = "Earth", RotationPeriod = 24, OrbitalPeriod = 365, Climate = "Temperate", Gravity = "1g", Terrain = "Various", SurfaceWater = 70, Population = 70000000 };
            _repositoryMock.Setup(r => r.GetEntityByIdAsync<Planet>(1)).ReturnsAsync(planet);

            // Act
            var result = await _planetService.GetPlanetFormByIdAsync(1);

            // Assert
            Assert.That(result.Name, Is.EqualTo("Earth"));
            Assert.That(result.RotationPeriod, Is.EqualTo("24"));
            Assert.That(result.OrbitalPeriod, Is.EqualTo("365"));
            Assert.That(result.Climate, Is.EqualTo("Temperate"));
            Assert.That(result.Gravity, Is.EqualTo("1g"));
            Assert.That(result.Terrain, Is.EqualTo("Various"));
            Assert.That(result.SurfaceWater, Is.EqualTo("70"));
            Assert.That(result.Population, Is.EqualTo("70000000"));
        }
    }
}
