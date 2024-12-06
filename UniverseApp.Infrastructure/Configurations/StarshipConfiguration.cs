using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniverseApp.Infrastructure.Data.DTOs;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Common.SeedDtoDataHelper;

namespace UniverseApp.Infrastructure.Configurations
{
    public class StarshipConfiguration : IEntityTypeConfiguration<Starship>
    {
        public void Configure(EntityTypeBuilder<Starship> builder)
        {
            var starshipsToImport = GetEntityDtoInfoAsync<StarshipInfoDto>().Result;

            var starships = starshipsToImport
                .Select(v => new Starship()
                {
                    Id = GetEntityIdFromUrl(v.Url),
                    Name = v.Name,
                    Model = v.Model,
                    Manufacturer = v.Manufacturer,
                    CostInCredits = v.CostInCredits != null ? TryParseInputToInt(v.CostInCredits) : null,
                    Length = v.Length != null ? TryParseInputToInt(v.Length) : null,
                    MaxAtmospheringSpeed = v.MaxAtmospheringSpeed != null ? TryParseInputToInt(v.MaxAtmospheringSpeed) : null,
                    Crew = v.Crew != null ? TryParseInputToInt(v.Crew) : null,
                    Passengers = v.Passengers != null ? TryParseInputToInt(v.Passengers) : null,
                    CargoCapacity = v.CargoCapacity != null ? TryParseInputToInt(v.CargoCapacity) : null,
                    Consumables = v.Consumables,
                    Class = v.Class,
                    HyperdriveRating = v.HyperdriveRating != null ? TryParseInputToInt(v.HyperdriveRating) : null,
                    MGLT = v.MGLT != null ? TryParseInputToInt(v.MGLT) : null,
                    Url = v.Url
                })
                .ToList();

            builder.HasData(starships);
        }
    }
}
