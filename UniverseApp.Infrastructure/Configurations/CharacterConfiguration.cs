using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniverseApp.Infrastructure.Data.DTOs;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Common.SeedDtoDataHelper;

namespace UniverseApp.Infrastructure.Configurations
{
    internal class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            var charactersToImport = GetEntityDtoInfoAsync<CharacterInfoDto>().Result;

            var characters = charactersToImport
                .Select(c => new Character()
                {
                    Id = GetEntityIdFromUrl(c.Url),
                    Name = c.Name,
                    Height = c.Height != null ? TryParseInputToInt(c.Height) : null,
                    Mass = c.Mass != null ? TryParseInputToInt(c.Mass) : null,
                    HairColor = c.HairColor,
                    SkinColor = c.SkinColor,
                    EyeColor = c.EyeColor,
                    BirthYear = c.BirthYear,
                    Gender = c.Gender,
                    Url = c.Url,
                    IsDeleted = false
                })
                .ToList();

            builder.HasData(characters);
        }
    }
}
