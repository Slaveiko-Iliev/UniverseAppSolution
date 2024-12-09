using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Models.Specie;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services
{
    public class SpecieService : ISpecieService
    {
        private readonly IRepository _repository;

        public SpecieService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<SpecieQueryServiceModel> GetAllSpeciesAsync(string? searchCharacter, string? searchMovie, int currentPage, int speciesPerPage)
        {
            var species = _repository
                .AllReadOnly<Specie>();

            if (!string.IsNullOrEmpty(searchCharacter))
            {
                species = species
                    .Where(m => m.Characters.Any(c => c.Name == searchCharacter));
            }

            if (!string.IsNullOrEmpty(searchMovie))
            {
                species = species
                    .Where(m => m.Movies.Any(p => p.Title == searchMovie));
            }

            var totalSpeciesCount = await species.CountAsync();

            species = species
                .OrderBy(m => m.Id)
                .Skip((currentPage - 1) * speciesPerPage)
                .Take(speciesPerPage);

            var specieViewModels = await species
                .Select(m => new SpecieAllViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Classification = m.Classification,
                    Designation = m.Designation,
                    AverageHeight = m.AverageHeight,
                    SkinColor = m.SkinColors,
                    HairColor = m.HairColors,
                    EyeColor = m.EyeColors,
                    AverageLifespan = m.AverageLifespan,
                    Language = m.Language
                })
                .ToListAsync();

            var specieAllQueryModels = new SpecieQueryServiceModel()
            {
                TotalSpeciesCount = totalSpeciesCount,
                Species = specieViewModels
            };

            return specieAllQueryModels;
        }
    }
}
