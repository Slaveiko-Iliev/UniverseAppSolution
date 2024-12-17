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
            builder.ApplyConfiguration(new UserClaimsConfigiration());
        }
    }
}
