using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniverseApp.Infrastructure.Data.DTOs;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Common.SeedDtoDataHelper;

namespace UniverseApp.Infrastructure.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            var vehiclesToImport = GetEntityDtoInfoAsync<VehicleInfoDto>().Result;

            var species = vehiclesToImport
                .Select(v => new Vehicle()
                {
                    Id = GetEntityIdFromUrl(v.Url),
                    Name = v.Name,
                    Model = v.Model,
                    Manufacturer = v.Manufacturer,
                    CostInCredits = v.CostInCredits != null ? TryParseInputToInt(v.CostInCredits) : null,
                    Length = v.Length != null ? TryParseInputToDouble(v.Length) : null,
                    MaxAtmospheringSpeed = v.MaxAtmospheringSpeed != null ? TryParseInputToInt(v.MaxAtmospheringSpeed) : null,
                    Crew = v.Crew != null ? TryParseInputToInt(v.Crew) : null,
                    Passengers = v.Passengers != null ? TryParseInputToInt(v.Passengers) : null,
                    CargoCapacity = v.CargoCapacity != null ? TryParseInputToInt(v.CargoCapacity) : null,
                    Consumables = v.Consumables,
                    Class = v.Class,
                    Url = v.Url
                })
                .ToList();

            builder.HasData(species);
        }
    }
}
