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

        public async Task AddMovieAsync(MovieFormModel model)
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
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllMoviesAsync()
        {
            var movies = await _repository
                .AllReadOnly<Movie>()
                .ToListAsync();

            var movieViewModels = new List<MovieViewModel>();

            foreach (var m in movies)
            {
                var movieViewModel = new MovieViewModel
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
    }
}
