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
            return RedirectToAction(nameof(Details), new { id = newMovieId });
        }

        public async Task<IActionResult> All([FromQuery] MovieAllQueryModel model)
        {
            var queryResult = await _movieService.GetAllMoviesAsync(model.SearchCharacter, model.SearchPlanet, model.CurrentPage, MovieAllQueryModel.MoviesPerPage);

            model.Movies = queryResult.Movies;
            model.TotalMoviesCount = queryResult.TotalMoviesCount;

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (await _movieService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var movie = await _movieService.GetMovieDetailsByIdAsync(id);

            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await _movieService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var movie = await _movieService.GetMovieFormByIdAsync(id);

            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MovieFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _movieService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            await _movieService.EditMovieAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _movieService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            MovieDeleteViewModel movie = await _movieService.GetMovieDeleteModelByIdAsync(id);

            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, MovieDeleteViewModel model)
        {
            if (await _movieService.ExistByIdAsync(model.Id) == false)
            {
                return BadRequest();
            }
            if (id != model.Id)
            {
                return BadRequest();
            }

            await _movieService.DeleteMovieAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
