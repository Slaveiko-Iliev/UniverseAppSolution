using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniverseApp.Infrastructure.Data.DTOs;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Common.SeedDtoDataHelper;

namespace UniverseApp.Infrastructure.Configurations
{
	public class MovieConfiguration : IEntityTypeConfiguration<Movie>
	{
		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			var moviesToImport = GetEntityDtoInfoAsync<MovieInfoDto>().Result;

			var movies = moviesToImport
				.Select(m => new Movie()
				{
					Id = GetEntityIdFromUrl(m.Url),
					Name = m.Name,
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
	}
}
