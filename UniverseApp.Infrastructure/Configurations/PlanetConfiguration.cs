using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniverseApp.Infrastructure.Data.DTOs;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Common.SeedDtoDataHelper;

namespace UniverseApp.Infrastructure.Configurations
{
    public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            var planetsToImport = GetEntityDtoInfoAsync<PlanetInfoDto>().Result;

            var planets = planetsToImport
                .Select(m => new Planet()
                {
                    Id = GetEntityIdFromUrl(m.Url),
                    Name = m.Name,
                    RotationPeriod = m.RotationPeriod != null ? TryParseInputToInt(m.RotationPeriod) : null,
                    OrbitalPeriod = m.OrbitalPeriod != null ? TryParseInputToInt(m.OrbitalPeriod) : null,
                    Diameter = m.Diameter != null ? TryParseInputToInt(m.Diameter) : null,
                    Climate = m.Climate != null ? SplitInput(m.Climate) : [],
                    Gravity = m.Gravity,
                    Terrain = m.Terrain != null ? SplitInput(m.Terrain) : [],
                    SurfaceWater = m.SurfaceWater != null ? TryParseInputToInt(m.SurfaceWater) : null,
                    Population = m.Population != null ? TryParseInputToInt(m.Population) : null,
                    Url = m.Url,
                    IsDeleted = false

                })
                .ToList();

            builder.HasData(planets);
        }
    }
}
