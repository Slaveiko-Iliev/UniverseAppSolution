using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.General;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.MovieConst;

namespace UniverseApp.Infrastructure.Data.DTOs
{
	public class MovieInfoDto
	{
		[Required]
		[StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		[JsonPropertyName("title")]
		public required string Name { get; set; }

		[Required]
		[JsonPropertyName("episode_id")]
		[StringLength(EpisodeIdMaxLenght, MinimumLength = EpisodeIdMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		public required int EpisodeId { get; set; }

		[Required]
		[JsonPropertyName("opening_crawl")]
		[StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		public required string Description { get; set; }

		[Required]
		[StringLength(DirectorMaxLenght, MinimumLength = DirectorMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		public required string Director { get; set; }

		[Required]
		[StringLength(ProducerMaxLenght, MinimumLength = ProducerMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		public required string Producer { get; set; }

		[Required]
		[JsonPropertyName("release_date")]
		public required string ReleaseDate { get; set; } // format "1977-05-25"

		public string[]? Characters { get; set; }

		public string[]? Planets { get; set; }

		public string[]? Starships { get; set; }

		public string[]? Vehicles { get; set; }

		public string[]? Species { get; set; }

		[Required]
		[StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		public string Url { get; set; } = null!;
	}
}
