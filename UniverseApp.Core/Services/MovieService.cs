using Microsoft.AspNetCore.Mvc;
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

        public async Task<IEnumerable<MovieAllViewModel>> GetAllMoviesAsync()
        {
            var movies = await _repository
                .AllReadOnly<Movie>()
                .ToListAsync();

            var movieViewModels = new List<MovieAllViewModel>();

            foreach (var m in movies)
            {
                var movieViewModel = new MovieAllViewModel
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
                };

                movieViewModels.Add(movieViewModel);
            }

            return movieViewModels;
        }

        public async Task<MovieDetailsViewModel> GetMovieByIdAsync(int newMovieId)
        {
            var movie = await _repository
                .GetEntityByIdAsync<Movie>(newMovieId);

            var movieDetails = new MovieDetailsViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                EpisodeId = movie.EpisodeId,
                Description = movie.Description,
                Director = movie.Director,
                Producer = movie.Producer,
                ReleaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd"),
                Url = movie.Url,
                ImageUrl = movie.ImageUrl
            };

            return movieDetails;
        }
    }
}
