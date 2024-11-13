using Microsoft.EntityFrameworkCore;
using UniverseApp.Infrastructure.Configurations;

namespace UniverseApp.Infrastructure.Extension
{
    internal static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new CharacterConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
        }
    }
}
