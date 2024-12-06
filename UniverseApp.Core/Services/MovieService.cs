using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Models.Movie;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository _repository;

        public MovieService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddMovieAsync(MovieFormModel model)
        {
            var movie = new Movie
            {
                Id = _repository.All<Movie>().Count() + 1,
                Title = model.Title,
                EpisodeId = model.EpisodeId,
                Description = model.Description,
                Director = model.Director,
                Producer = model.Producer,
                ReleaseDate = DateTime.Parse(model.ReleaseDate),
                Url = model.Url,
                ImageUrl = model.ImageUrl
            };

            await _repository.AddAsync(movie);
            await _repository.SaveChangesAsync();

            return movie.Id;
        }

        public Task<bool> ExistByIdAsync(int id) =>
            _repository
                .AllReadOnly<Movie>()
                .AnyAsync(m => m.Id == id);

        public async Task<MovieQueryServiceModel> GetAllMoviesAsync(string searchCharacter, string searchPlanet, int currentPage, int moviesPerPage)
        {
            var movies = _repository
                .AllReadOnly<Movie>()
                .Where(m => !m.IsDeleted);

            if (!string.IsNullOrEmpty(searchCharacter))
            {
                movies = movies
                    .Where(m => m.Characters.Any(c => c.Name == searchCharacter));
            }

            if (!string.IsNullOrEmpty(searchPlanet))
            {
                movies = movies
                    .Where(m => m.Planets.Any(p => p.Name == searchPlanet));
            }

            var totalMoviesCount = await movies.CountAsync();

            movies = movies
                .OrderBy(m => m.Id)
                .Skip((currentPage - 1) * moviesPerPage)
                .Take(moviesPerPage);

            var movieViewModels = await movies
                .Select(m => new MovieAllViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    EpisodeId = m.EpisodeId,
                    Description = m.Description,
                    Director = m.Director,
                    Producer = m.Producer,
                    ReleaseDate = m.ReleaseDate.ToString("yyyy-MM-dd"),
                    Url = m.Url,
                    ImageUrl = m.ImageUrl
                })
                .ToListAsync();

            var movieAllQueryModels = new MovieQueryServiceModel()
            {
                TotalMoviesCount = totalMoviesCount,
                Movies = movieViewModels
            };

            return movieAllQueryModels;
        }

        public async Task<MovieDetailsViewModel> GetMovieDetailsByIdAsync(int id)
        {
            var movie = await _repository
                .GetEntityByIdAsync<Movie>(id);

            var charactersNames = await _repository.GetEntitiesNames<Character>(movie.Characters);
            var planetsNames = await _repository.GetEntitiesNames<Planet>(movie.Planets);
            var starshipsNames = await _repository.GetEntitiesNames<Starship>(movie.Starships);
            var vehiclesNames = await _repository.GetEntitiesNames<Vehicle>(movie.Vehicles);
            var speciesNames = await _repository.GetEntitiesNames<Specie>(movie.Species);

            var movieDetails = new MovieDetailsViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                EpisodeId = movie.EpisodeId,
                Description = movie.Description,
                Director = movie.Director,
                Producer = movie.Producer,
                ReleaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd"),
                CharactersNames = charactersNames,
                PlanetsNames = planetsNames,
                StarshipsNames = starshipsNames,
                VehiclesNames = vehiclesNames,
                SpeciesNames = speciesNames,
                Url = movie.Url,
                ImageUrl = movie.ImageUrl
            };

            return movieDetails;
        }

        public async Task<MovieFormModel> GetMovieFormByIdAsync(int id)
        {
            var movie = await _repository
                .GetEntityByIdAsync<Movie>(id);

            var movieFormModel = new MovieFormModel
            {
                Title = movie.Title,
                EpisodeId = movie.EpisodeId,
                Description = movie.Description,
                Director = movie.Director,
                Producer = movie.Producer,
                ReleaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd"),
                Url = movie.Url,
                ImageUrl = movie.ImageUrl
            };

            return movieFormModel;
        }

        public async Task EditMovieAsync(int id, MovieFormModel model)
        {
            var movie = await _repository
                .GetEntityByIdAsync<Movie>(id);

            movie.Title = model.Title;
            movie.EpisodeId = model.EpisodeId;
            movie.Description = model.Description;
            movie.Director = model.Director;
            movie.Producer = model.Producer;
            movie.ReleaseDate = DateTime.Parse(model.ReleaseDate);
            movie.Url = model.Url;
            movie.ImageUrl = model.ImageUrl;

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _repository
                .All<Movie>()
                .FirstAsync(m => m.Id == id);

            movie.IsDeleted = true;
            await _repository.SaveChangesAsync();
        }

        public async Task<MovieDeleteViewModel> GetMovieDeleteModelByIdAsync(int id)
        {
            var movie = await _repository
                .GetEntityByIdAsync<Movie>(id);

            var movieDeleteModel = new MovieDeleteViewModel
            {
                Title = movie.Title,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd"),
                ImageUrl = movie.ImageUrl
            };

            return movieDeleteModel;
        }
    }
}
