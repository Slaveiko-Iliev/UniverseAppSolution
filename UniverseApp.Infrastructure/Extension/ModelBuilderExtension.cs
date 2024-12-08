using Microsoft.EntityFrameworkCore;
using UniverseApp.Infrastructure.Configurations;

namespace UniverseApp.Infrastructure.Extension
{
    internal static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new PlanetConfiguration());
            builder.ApplyConfiguration(new CharacterConfiguration());
            builder.ApplyConfiguration(new SpecieConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new StarshipConfiguration());
        }
    }
}
