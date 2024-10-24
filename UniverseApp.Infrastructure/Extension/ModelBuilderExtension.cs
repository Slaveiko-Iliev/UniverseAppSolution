using Microsoft.EntityFrameworkCore;

namespace UniverseApp.Infrastructure.Extension
{
    internal static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MovieConfiguration());
        }
    }
}
