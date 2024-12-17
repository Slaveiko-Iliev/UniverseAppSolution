using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Models.Specie;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.DTOs;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services
{
    public class SpecieService : ISpecieService
    {
        private readonly IRepository _repository;
        private readonly IServiceHelper _serviceHelper;

        public SpecieService(IRepository repository, IServiceHelper serviceHelper)
        {
            _repository = repository;
            _serviceHelper = serviceHelper;
        }

        public async Task<int> AddSpecieAsync(SpecieFormModel model)
        {
            int? averageHeight = model.AverageHeight != null
                ? _serviceHelper.TryParseInputToInt(model.AverageHeight)
                : null;
            int? averageLifespan = model.AverageLifespan != null
                ? _serviceHelper.TryParseInputToInt(model.AverageLifespan)
                : null;

            var newSpecie = new Specie()
            {
                Id = _repository.AllReadOnly<Specie>().Count() + 1,
                Name = model.Name,
                Classification = model.Classification,
                Designation = model.Designation,
                AverageHeight = averageHeight,
                SkinColors = model.SkinColor,
                HairColors = model.HairColor,
                EyeColors = model.EyeColor,
                AverageLifespan = averageLifespan,
                Language = model.Language,
            };

            await _repository.AddAsync(newSpecie);
            await _repository.SaveChangesAsync();

            return newSpecie.Id;
        }

        public async Task AddSpecieRangeAsync(List<SpecieInfoDto> specieDtoList)
        {
            ICollection<Specie> species = new List<Specie>();

            foreach (var specieDto in specieDtoList)
            {
                var specieId = _serviceHelper.GetEntityIdFromUrl(specieDto.Url);

                if (!await _repository.AllReadOnly<Specie>().AnyAsync(p => p.Id == specieId)
                    && !await _repository.AllReadOnly<Specie>().AnyAsync(p => p.Name == specieDto.Name))
                {
                    var newSpecie = new Specie()
                    {
                        Id = specieId,
                        Name = specieDto.Name,
                        Classification = specieDto.Classification,
                        Designation = specieDto.Designation,
                        AverageHeight = specieDto.AverageHeight != null
                            ? _serviceHelper.TryParseInputToInt(specieDto.AverageHeight)
                            : null,
                        SkinColors = specieDto.SkinColors,
                        HairColors = specieDto.HairColors,
                        EyeColors = specieDto.EyeColors,
                        AverageLifespan = specieDto.AverageLifespan != null
                            ? _serviceHelper.TryParseInputToInt(specieDto.AverageLifespan)
                            : null,
                        Language = specieDto.Language,
                        PlanetId = specieDto.PlanetId != null
                            ? _serviceHelper.GetEntityIdFromUrl(specieDto.PlanetId)
                            : null,
                        Url = specieDto.Url
                    };

                    if (specieDto.Characters != null)
                    {
                        foreach (var characterUrl in specieDto.Characters)
                        {
                            var characterId = _serviceHelper.GetEntityIdFromUrl(characterUrl);
                            if (!await _repository.AllReadOnly<Character>().AnyAsync(ch => ch.Id == characterId))
                            {
                                continue;
                            }

                            var character = await _repository.GetEntityByIdAsync<Character>(characterId);
                            newSpecie.Characters.Add(character);
                        }
                    }

                    species.Add(newSpecie);
                }
            }

            await _repository.AddRangeAsync<Specie>(species);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteSpecieAsync(int id)
        {
            var specie = await _repository
                .All<Specie>()
                .FirstAsync(m => m.Id == id);

            specie.IsDeleted = true;
            await _repository.SaveChangesAsync();
        }

        public async Task EditSpecieAsync(int id, SpecieFormModel model)
        {
            var specie = await _repository
                .GetEntityByIdAsync<Specie>(id);

            specie.Name = model.Name;
            specie.Classification = model.Classification;
            specie.Designation = model.Designation;
            specie.AverageHeight = model.AverageHeight != null
                ? _serviceHelper.TryParseInputToInt(model.AverageHeight)
                : null;
            specie.SkinColors = model.SkinColor;
            specie.HairColors = model.HairColor;
            specie.EyeColors = model.EyeColor;
            specie.AverageLifespan = model.AverageLifespan != null
                ? _serviceHelper.TryParseInputToInt(model.AverageLifespan)
                : null;
            specie.Language = model.Language;

            await _repository.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(int id) =>
            await _repository
                .AllReadOnly<Specie>()
                .Where(m => !m.IsDeleted)
                .AnyAsync(m => m.Id == id);

        public async Task<SpecieQueryServiceModel> GetAllSpeciesAsync(string? searchCharacter, string? searchMovie, int currentPage, int speciesPerPage)
        {
            var species = _repository
                .AllReadOnly<Specie>()
                .Where(v => !v.IsDeleted);

            if (!string.IsNullOrEmpty(searchCharacter))
            {
                species = species
                    .Where(m => m.Characters.Any(c => c.Name == searchCharacter));
            }

            if (!string.IsNullOrEmpty(searchMovie))
            {
                species = species
                    .Where(m => m.Movies.Any(p => p.Name == searchMovie));
            }

            var totalSpeciesCount = await species.CountAsync();

            species = species
                .OrderBy(m => m.Id)
                .Skip((currentPage - 1) * speciesPerPage)
                .Take(speciesPerPage);

            var specieViewModels = await species
                .Select(s => new SpecieAllViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Classification = s.Classification,
                    Designation = s.Designation,
                    AverageHeight = s.AverageHeight.ToString(),
                    SkinColor = s.SkinColors,
                    HairColor = s.HairColors,
                    EyeColor = s.EyeColors,
                    AverageLifespan = s.AverageLifespan.ToString(),
                    Language = s.Language
                })
                .ToListAsync();

            var specieAllQueryModels = new SpecieQueryServiceModel()
            {
                TotalSpeciesCount = totalSpeciesCount,
                Species = specieViewModels
            };

            return specieAllQueryModels;
        }

        public async Task<SpecieDeleteViewModel> GetSpecieDeleteModelByIdAsync(int id)
        {
            var specie = await _repository
                .GetEntityByIdAsync<Specie>(id);

            var specieDeleteModel = new SpecieDeleteViewModel
            {
                Name = specie.Name,
                Classification = specie.Classification,
                Designation = specie.Designation,
                Homeworld = specie.Planet?.Name
            };

            return specieDeleteModel;
        }

        public async Task<SpecieDetailsViewModel> GetSpecieDetailsByIdAsync(int id)
        {
            var specie = await _repository
                .GetEntityByIdAsync<Specie>(id);

            var charactersNames = await _repository.GetEntitiesNames<Character>(specie.Characters);
            var moviesNames = await _repository.GetEntitiesNames<Movie>(specie.Movies);

            var specieDetails = new SpecieDetailsViewModel
            {
                Id = specie.Id,
                Name = specie.Name,
                Classification = specie.Classification,
                Designation = specie.Designation,
                AverageHeight = specie.AverageHeight.ToString(),
                SkinColor = specie.SkinColors,
                HairColor = specie.HairColors,
                EyeColor = specie.EyeColors,
                AverageLifespan = specie.AverageLifespan.ToString(),
                Language = specie.Language,
                CharactersNames = charactersNames,
                MoviesNames = moviesNames
            };

            return specieDetails;
        }

        public async Task<SpecieFormModel> GetSpecieFormByIdAsync(int id)
        {
            var specie = await _repository
                .GetEntityByIdAsync<Specie>(id);

            var specieFormModel = new SpecieFormModel
            {
                Name = specie.Name,
                Classification = specie.Classification,
                Designation = specie.Designation,
                AverageHeight = specie.AverageHeight.ToString(),
                SkinColor = specie.SkinColors,
                HairColor = specie.HairColors,
                EyeColor = specie.EyeColors,
                AverageLifespan = specie.AverageLifespan.ToString(),
                Language = specie.Language
            };

            return specieFormModel;
        }
    }
}
