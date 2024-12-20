﻿using UniverseApp.Core.Models.Movie;
using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Core.Services.Contracts
{
    public interface IMovieService
    {
        Task<int> AddMovieAsync(MovieFormModel model);
        Task EditMovieAsync(int id, MovieFormModel model);
        Task<bool> ExistByIdAsync(int id);
        Task<MovieQueryServiceModel> GetAllMoviesAsync(string searchCharacter, string searchPlanet, string searchSpecie, string searchVehicle, int currentPage, int moviesPerPage);
        Task<MovieFormModel> GetMovieFormByIdAsync(int id);
        Task<MovieDetailsViewModel> GetMovieDetailsByIdAsync(int id);
        Task DeleteMovieAsync(int id);
        Task<MovieDeleteViewModel> GetMovieDeleteModelByIdAsync(int id);
        Task AddMovieRangeAsync(ICollection<MovieInfoDto> movieDtoList);
        Task AddMovieRelationshipAsync(ICollection<MovieInfoDto> movieDtoList);
    }
}
