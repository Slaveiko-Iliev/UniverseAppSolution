using Microsoft.AspNetCore.Mvc;
using UniverseApp.Core.Models.Movie;
using UniverseApp.Core.Services.Contracts;

namespace UniverseApp.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Add()
        {
            var model = new MovieFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _movieService.AddMovieAsync(model);
            return RedirectToAction(nameof(Details));
        }

        public async Task<IActionResult> Details()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return View(movies);
        }
    }
}
