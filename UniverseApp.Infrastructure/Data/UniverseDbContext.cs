using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniverseApp.Infrastructure.Data.Models;
using UniverseApp.Infrastructure.Extension;

namespace UniverseApp.Infrastructure.Data
{
    public class UniverseDbContext : IdentityDbContext<UniverseUser>
    {
        public UniverseDbContext(DbContextOptions<UniverseDbContext> options)
            : base(options)
        {
        }

        public required DbSet<Movie> Movies { get; set; }
        public required DbSet<Character> Characters { get; set; }
        public required DbSet<Planet> Planets { get; set; }
        public required DbSet<Specie> Species { get; set; }
        public required DbSet<Starship> Starships { get; set; }
        public required DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();

            base.OnModelCreating(builder);
        }

    }
}
