using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseApp.Core.Models.Movie;

namespace UniverseApp.Core.Services.Contracts
{
    public interface IMovieService
    {
        Task<int> AddMovieAsync(MovieFormModel model);
        Task EditMovieAsync(int id, MovieFormModel model);
        Task<bool> ExistByIdAsync(int id);
        Task<IEnumerable<MovieAllViewModel>> GetAllMoviesAsync();
        Task<MovieFormModel> GetMovieFormByIdAsync(int id);
        Task<MovieDetailsViewModel> GetMovieDetailsByIdAsync(int id);
        Task DeleteMovieAsync(int id);
    }
}
