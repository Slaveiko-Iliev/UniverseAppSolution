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
        Task<bool> ExistByIdAsync(int id);
        Task<IEnumerable<MovieAllViewModel>> GetAllMoviesAsync();
        Task<MovieDetailsViewModel> GetMovieByIdAsync(int newMovieId);
    }
}
