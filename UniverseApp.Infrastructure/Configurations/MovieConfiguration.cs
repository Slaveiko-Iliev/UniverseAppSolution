using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            var movieTotImport = GetEntityDtoInfoAsync<MovieInfoDto>().Result;

            var movies = movieTotImport
                .Select(m => new Movie()
                {
                    Id = GetEntityIdFromUrl(m.Url) + 4,
                    Title = m.Title,
                    EpisodeId = m.EpisodeId.ToString(),
                    Description = m.Description,
                    Director = m.Director,
                    Producer = m.Producer,
                    ReleaseDate = DateTime.Parse(m.ReleaseDate),
                    Url = m.Url,
                    ImageUrl = string.Empty,
                    IsDeleted = false
                })
                .ToList();

            builder.HasData(movies);
        }

        public int GetEntityIdFromUrl(string url)
        {
            string pattern = @"(\d+)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(url);
            return int.Parse(match.Value);
        }
    }
}
