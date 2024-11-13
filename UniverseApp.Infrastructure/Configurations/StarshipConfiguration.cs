using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Infrastructure.Configurations
{
    internal class StarshipConfiguration : IEntityTypeConfiguration<Starship>
    {
        public void Configure(EntityTypeBuilder<Starship> builder)
        {
            throw new NotImplementedException();
        }
    }
}
