using UniverseApp.Core.Models.Movie;

namespace UniverseApp.Core.Services.Contracts
{
	public interface IMovieService
	{
		Task<int> AddMovieAsync(MovieFormModel model);
		Task EditMovieAsync(int id, MovieFormModel model);
		Task<bool> ExistByIdAsync(int id);
		Task<MovieQueryServiceModel> GetAllMoviesAsync(string searchCharacter, string searchPlanet, int currentPage, int moviesPerPage);
		Task<MovieFormModel> GetMovieFormByIdAsync(int id);
		Task<MovieDetailsViewModel> GetMovieDetailsByIdAsync(int id);
		Task DeleteMovieAsync(int id);

	}
}
