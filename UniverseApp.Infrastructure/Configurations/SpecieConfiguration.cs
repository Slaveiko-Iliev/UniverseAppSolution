using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using UniverseApp.Infrastructure.Data.Models;
namespace UniverseApp.Infrastructure.Configurations
{
    internal class SpecieConfiguration : IEntityTypeConfiguration<Specie>
    {
        public void Configure(EntityTypeBuilder<Specie> builder)
        {
            throw new NotImplementedException();
        }
    }
}
