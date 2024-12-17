using MockQueryable;
using Moq;
using UniverseApp.Core.Models.Movie;
using UniverseApp.Core.Services;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Tests
{
    public class MovieServicesTests
    {
        private Mock<IRepository> _repositoryMock;
        private MovieService _movieService;
        private Mock<IServiceHelper> _serviceHelperMock;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository>();
            _serviceHelperMock = new Mock<IServiceHelper>();
            _movieService = new MovieService(_repositoryMock.Object, _serviceHelperMock.Object);
        }

        [Test]
        public async Task AddMovieAsync_ShouldAddMovieAndReturnId()
        {
            // Arrange
            var model = new MovieFormModel
            {
                Name = "Test Movie",
                EpisodeId = "1",
                Description = "Test Description",
                Director = "Test Director",
                Producer = "Test Producer",
                ReleaseDate = "2023-01-01",
                Url = "http://test.com",
                ImageUrl = "http://test.com/image.jpg"
            };

            _repositoryMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
            _repositoryMock.Setup(r => r.AllReadOnly<Movie>()).Returns(new List<Movie>().AsQueryable());
            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Movie>())).Returns(Task.CompletedTask);

            // Act
            var result = await _movieService.AddMovieAsync(model);

            // Assert
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Movie>()), Times.Once);
            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task ExistByIdAsync_ShouldReturnTrueIfMovieExists()
        {
            // Arrange
            var movieId = 1;
            var movies = new List<Movie>
            {
                new Movie { Id = movieId, IsDeleted = false }
            }.AsQueryable();
            var mock = movies.BuildMock();

            _repositoryMock.Setup(r => r.AllReadOnly<Movie>()).Returns(mock);

            // Act
            var result = await _movieService.ExistByIdAsync(movieId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetAllMoviesAsync_ShouldReturnMovies()
        {
            // Arrange
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Movie 1", IsDeleted = false },
                new Movie { Id = 2, Name = "Movie 2", IsDeleted = false }
            }.AsQueryable();
            var mock = movies.BuildMock();

            _repositoryMock.Setup(r => r.AllReadOnly<Movie>()).Returns(mock);

            // Act
            var result = await _movieService.GetAllMoviesAsync(null, null, null, null, 1, 10);

            // Assert
            Assert.That(result.TotalMoviesCount, Is.EqualTo(2));
            Assert.That(result.Movies.Count(), Is.EqualTo(2));
        }
        [Test]
        public async Task EditMovieAsync_ShouldEditMovie()
        {
            // Arrange
            var movieId = 1;
            var movie = new Movie { Id = movieId, Name = "Old Name" };
            var model = new MovieFormModel
            {
                Name = "New Name",
                EpisodeId = "1",
                Description = "New Description",
                Director = "New Director",
                Producer = "New Producer",
                ReleaseDate = "2023-01-01",
                Url = "http://new.com",
                ImageUrl = "http://new.com/image.jpg"
            };

            _repositoryMock.Setup(r => r.GetEntityByIdAsync<Movie>(movieId)).ReturnsAsync(movie);
            _repositoryMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            await _movieService.EditMovieAsync(movieId, model);

            // Assert
            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.AreEqual("New Name", movie.Name);
        }

        [Test]
        public async Task DeleteMovieAsync_ShouldMarkMovieAsDeleted()
        {
            // Arrange
            var movieId = 1;
            var movies = new List<Movie> { new Movie { Id = movieId, IsDeleted = false } }.AsQueryable();
            var mock = movies.BuildMock();

            _repositoryMock.Setup(x => x.All<Movie>()).Returns(mock);
            _repositoryMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            await _movieService.DeleteMovieAsync(movieId);

            // Assert
            Assert.IsTrue(movies.Where(v => v.Id == 1).Any(v => v.IsDeleted));
            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetMovieDeleteModelByIdAsync_ShouldReturnMovieDeleteModel()
        {
            // Arrange
            var movieId = 1;
            var movie = new Movie { Id = movieId, Name = "Test Movie", Director = "Test Director", ReleaseDate = DateTime.Parse("2023-01-01"), ImageUrl = "http://test.com/image.jpg" };
            _repositoryMock.Setup(r => r.GetEntityByIdAsync<Movie>(movieId)).ReturnsAsync(movie);

            // Act
            var result = await _movieService.GetMovieDeleteModelByIdAsync(movieId);

            // Assert
            Assert.AreEqual("Test Movie", result.Name);
            Assert.AreEqual("Test Director", result.Director);
            Assert.AreEqual("2023-01-01", result.ReleaseDate);
            Assert.AreEqual("http://test.com/image.jpg", result.ImageUrl);
        }
    }
}