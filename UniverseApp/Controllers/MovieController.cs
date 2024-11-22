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

        [HttpGet]
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

            int newMovieId = await _movieService.AddMovieAsync(model);
            return RedirectToAction(nameof(Details), newMovieId);
        }

        public async Task<IActionResult> All()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            if(await _movieService.ExistByIdAsync(id) == false)
            {
                return NotFound();
            }

            var movie = await _movieService.GetMovieByIdAsync(id);

            return View(movie);
        }

        
    }
}
