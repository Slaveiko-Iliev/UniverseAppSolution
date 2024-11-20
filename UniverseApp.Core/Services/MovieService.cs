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
        private readonly IServiceHelper _serviceHelper;

        public MovieService(IRepository repository, IServiceHelper serviceHelper)
        {
            _repository = repository;
            _serviceHelper = serviceHelper;
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllMoviesAsync()
        {
            var movies = await _repository
                .AllReadOnly<Movie>()
                .ToListAsync();

            var movieViewModels = new List<MovieViewModel>();

            foreach (var m in movies)
            {
                var characters = await _serviceHelper.GetIdsOfEntitiesAsync<Character>(m.Characters);
                var planets = await _serviceHelper.GetIdsOfEntitiesAsync<Planet>(m.Planets);
                var starships = await _serviceHelper.GetIdsOfEntitiesAsync<Starship>(m.Starships);
                var vehicles = await _serviceHelper.GetIdsOfEntitiesAsync<Vehicle>(m.Vehicles);
                var species = await _serviceHelper.GetIdsOfEntitiesAsync<Specie>(m.Species);

                var movieViewModel = new MovieViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    EpisodeId = m.EpisodeId,
                    Description = m.Description,
                    Director = string.Join(", ", m.Director),
                    Producer = string.Join(", ", m.Producer),
                    ReleaseDate = m.ReleaseDate.ToString("yyyy-MM-dd"),
                    Characters = characters,
                    Planets = planets,
                    Starships = starships,
                    Vehicles = vehicles,
                    Species = species,
                    Url = m.Url,
                    ImageUrl = m.ImageUrl
                };

                movieViewModels.Add(movieViewModel);
            }

            return movieViewModels;
        }
    }
}
