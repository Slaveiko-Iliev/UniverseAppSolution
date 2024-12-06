using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniverseApp.Infrastructure.Data.DTOs;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Common.SeedDtoDataHelper;


namespace UniverseApp.Infrastructure.Configurations
{
    public class SpecieConfiguration : IEntityTypeConfiguration<Specie>
    {
        public void Configure(EntityTypeBuilder<Specie> builder)
        {
            var speciesToImport = GetEntityDtoInfoAsync<SpecieInfoDto>().Result;

            var species = speciesToImport
                .Select(s => new Specie()
                {
                    Id = GetEntityIdFromUrl(s.Url),
                    Name = s.Name,
                    Classification = s.Classification,
                    Designation = s.Designation,
                    AverageHeight = s.AverageHeight,
                    SkinColors = s.SkinColors,
                    HairColors = s.HairColors,
                    EyeColors = s.EyeColors,
                    AverageLifespan = s.AverageLifespan,
                    PlanetId = s.PlanetId != null ? GetEntityIdFromUrl(s.PlanetId) : null,
                    Language = s.Language,
                    Url = s.Url,
                })
                .ToList();

            builder.HasData(species);
        }
    }
}
