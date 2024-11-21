using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using UniverseApp.Infrastructure.Data.DTOs;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Common.DataDtoHelper;

namespace UniverseApp.Infrastructure.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            var movieTotImport =  GetEntityDtoInfoAsync<MovieInfoDto>().Result;

            var movies = movieTotImport
                .Select(m => new Movie()
                {
                    //Id = GetEntityIdFromUrl(m.Url),
                    Title = m.Title,
                    EpisodeId = m.EpisodeId,
                    Description = m.Description,
                    Director = m.Director,
                    Producer = m.Producer,
                    ReleaseDate = DateTime.Parse(m.ReleaseDate),
                    Url = m.Url
                })
                .ToList();

            builder.HasData(movies);
        }
    }
}
