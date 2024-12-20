﻿using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Models.Movie;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.DTOs;
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
                Id = _repository.AllReadOnly<Movie>().Count() + 1,
                Name = model.Name,
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

        public async Task<bool> ExistByIdAsync(int id) =>
            await _repository
                .AllReadOnly<Movie>()
                .Where(m => !m.IsDeleted)
                .AnyAsync(m => m.Id == id);

        public async Task<MovieQueryServiceModel> GetAllMoviesAsync(string searchCharacter, string searchPlanet, string searchSpecie, string searchVehicle, int currentPage, int moviesPerPage)
        {
            var movies = _repository
                .AllReadOnly<Movie>()
                .Where(m => !m.IsDeleted);

            if (!string.IsNullOrEmpty(searchCharacter))
            {
                movies = movies
                    .Where(m => m.Characters.Any(c => c.Name == searchCharacter));
            }

            if (!string.IsNullOrEmpty(searchPlanet))
            {
                movies = movies
                    .Where(m => m.Planets.Any(p => p.Name == searchPlanet));
            }
            if (!string.IsNullOrEmpty(searchSpecie))
            {
                movies = movies
                    .Where(m => m.Species.Any(p => p.Name == searchSpecie));
            }
            if (!string.IsNullOrEmpty(searchVehicle))
            {
                movies = movies
                    .Where(m => m.Vehicles.Any(p => p.Name == searchVehicle));
            }

            var totalMoviesCount = await movies.CountAsync();

            movies = movies
                .OrderBy(m => m.Id)
                .Skip((currentPage - 1) * moviesPerPage)
                .Take(moviesPerPage);

            var movieViewModels = await movies
                .Select(m => new MovieAllViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    EpisodeId = m.EpisodeId,
                    Description = m.Description,
                    Director = m.Director,
                    Producer = m.Producer,
                    ReleaseDate = m.ReleaseDate.ToString("yyyy-MM-dd"),
                    Url = m.Url,
                    ImageUrl = m.ImageUrl
                })
                .ToListAsync();

            var movieAllQueryModels = new MovieQueryServiceModel()
            {
                TotalMoviesCount = totalMoviesCount,
                Movies = movieViewModels
            };

            return movieAllQueryModels;
        }

        public async Task<MovieDetailsViewModel> GetMovieDetailsByIdAsync(int id)
        {
            var movie = await _repository
                .GetEntityByIdAsync<Movie>(id);

            var charactersNames = await _repository.GetEntitiesNames<Character>(movie.Characters);
            var planetsNames = await _repository.GetEntitiesNames<Planet>(movie.Planets);
            var starshipsNames = await _repository.GetEntitiesNames<Starship>(movie.Starships);
            var vehiclesNames = await _repository.GetEntitiesNames<Vehicle>(movie.Vehicles);
            var speciesNames = await _repository.GetEntitiesNames<Specie>(movie.Species);

            var movieDetails = new MovieDetailsViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                EpisodeId = movie.EpisodeId,
                Description = movie.Description,
                Director = movie.Director,
                Producer = movie.Producer,
                ReleaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd"),
                CharactersNames = charactersNames,
                PlanetsNames = planetsNames,
                StarshipsNames = starshipsNames,
                VehiclesNames = vehiclesNames,
                SpeciesNames = speciesNames,
                Url = movie.Url,
                ImageUrl = movie.ImageUrl
            };

            return movieDetails;
        }

        public async Task<MovieFormModel> GetMovieFormByIdAsync(int id)
        {
            var movie = await _repository
                .GetEntityByIdAsync<Movie>(id);

            var movieFormModel = new MovieFormModel
            {
                Name = movie.Name,
                EpisodeId = movie.EpisodeId,
                Description = movie.Description,
                Director = movie.Director,
                Producer = movie.Producer,
                ReleaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd"),
                Url = movie.Url,
                ImageUrl = movie.ImageUrl
            };

            return movieFormModel;
        }

        public async Task EditMovieAsync(int id, MovieFormModel model)
        {
            var movie = await _repository
                .GetEntityByIdAsync<Movie>(id);

            movie.Name = model.Name;
            movie.EpisodeId = model.EpisodeId;
            movie.Description = model.Description;
            movie.Director = model.Director;
            movie.Producer = model.Producer;
            movie.ReleaseDate = DateTime.Parse(model.ReleaseDate);
            movie.Url = model.Url;
            movie.ImageUrl = model.ImageUrl;

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _repository
                .All<Movie>()
                .FirstAsync(m => m.Id == id);

            movie.IsDeleted = true;
            await _repository.SaveChangesAsync();
        }

        public async Task<MovieDeleteViewModel> GetMovieDeleteModelByIdAsync(int id)
        {
            var movie = await _repository
                .GetEntityByIdAsync<Movie>(id);

            var movieDeleteModel = new MovieDeleteViewModel
            {
                Name = movie.Name,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd"),
                ImageUrl = movie.ImageUrl
            };

            return movieDeleteModel;
        }

        public async Task AddMovieRangeAsync(ICollection<MovieInfoDto> movieDtoList)
        {
            ICollection<Movie> movies = new List<Movie>();

            foreach (var movieDto in movieDtoList)
            {
                var movieId = _serviceHelper.GetEntityIdFromUrl(movieDto.Url);

                if (!await _repository.AllReadOnly<Movie>().AnyAsync(p => p.Id == movieId)
                    && !await _repository.AllReadOnly<Movie>().AnyAsync(p => p.Name == movieDto.Name))
                {
                    var newMovie = new Movie()
                    {
                        Id = movieId,
                        Name = movieDto.Name,
                        EpisodeId = movieDto.EpisodeId.ToString(),
                        Description = movieDto.Description.Replace("\r\n", " ").Replace("\r\n", " "),
                        Director = movieDto.Director,
                        Producer = movieDto.Producer,
                        ReleaseDate = DateTime.Parse(movieDto.ReleaseDate),
                        Url = movieDto.Url
                    };

                    movies.Add(newMovie);
                }
            }

            await _repository.AddRangeAsync<Movie>(movies);
            await _repository.SaveChangesAsync();
        }

        public async Task AddMovieRelationshipAsync(ICollection<MovieInfoDto> movieDtoList)
        {
            foreach (var movieDto in movieDtoList)
            {
                var movieId = _serviceHelper.GetEntityIdFromUrl(movieDto.Url);

                if (await _repository.AllReadOnly<Movie>().AnyAsync(p => p.Id == movieId)
                    && await _repository.AllReadOnly<Movie>().AnyAsync(p => p.Name == movieDto.Name))
                {
                    var movie = await _repository.GetEntityByIdAsync<Movie>(movieId);

                    if (movieDto.Vehicles != null)
                    {
                        foreach (var vehicleUrl in movieDto.Vehicles)
                        {
                            var vehicleId = _serviceHelper.GetEntityIdFromUrl(vehicleUrl);
                            var vehicle = await _repository.All<Vehicle>().FirstOrDefaultAsync(v => v.Id == vehicleId);

                            if (vehicle != null
                                && !movie.Vehicles.Any(v => v.Id == vehicleId)
                                && !vehicle.Movies.Any(m => m.Id == movieId))
                            {
                                movie.Vehicles.Add(vehicle);
                                vehicle.Movies.Add(movie);
                            }
                        }
                    }

                    if (movieDto.Species != null)
                    {
                        foreach (var specieUrl in movieDto.Species)
                        {
                            var specieId = _serviceHelper.GetEntityIdFromUrl(specieUrl);
                            var specie = await _repository.All<Specie>().FirstOrDefaultAsync(v => v.Id == specieId);

                            if (specie != null
                                && !movie.Vehicles.Any(v => v.Id == specieId)
                                && !specie.Movies.Any(m => m.Id == movieId))
                            {
                                movie.Species.Add(specie);
                                specie.Movies.Add(movie);
                            }
                        }
                    }

                    if (movieDto.Characters != null)
                    {
                        foreach (var characterUrl in movieDto.Characters)
                        {
                            var characterId = _serviceHelper.GetEntityIdFromUrl(characterUrl);
                            var character = await _repository.All<Character>().FirstOrDefaultAsync(v => v.Id == characterId);

                            if (character != null
                                && !movie.Characters.Any(v => v.Id == characterId)
                                && !character.Movies.Any(m => m.Id == movieId))
                            {
                                movie.Characters.Add(character);
                                character.Movies.Add(movie);
                            }
                        }
                    }

                    if (movieDto.Planets != null)
                    {
                        foreach (var planetUrl in movieDto.Planets)
                        {
                            var planetId = _serviceHelper.GetEntityIdFromUrl(planetUrl);
                            var planet = await _repository.All<Planet>().FirstOrDefaultAsync(v => v.Id == planetId);

                            if (planet != null
                                && !movie.Planets.Any(v => v.Id == planetId)
                                && !planet.Movies.Any(m => m.Id == movieId))
                            {
                                movie.Planets.Add(planet);
                                planet.Movies.Add(movie);
                            }
                        }
                    }
                }
            }

            await _repository.SaveChangesAsync();
        }
    }
}
