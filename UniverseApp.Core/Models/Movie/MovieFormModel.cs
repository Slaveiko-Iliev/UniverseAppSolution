using System.ComponentModel.DataAnnotations;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.General;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.MovieConst;

namespace UniverseApp.Core.Models.Movie
{
	public class MovieFormModel
	{
		[Required(ErrorMessage = RequiredFieldErrorMesssage)]
		[StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredFieldErrorMesssage)]
		[StringLength(EpisodeIdMaxLenght, MinimumLength = EpisodeIdMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		[Display(Name = "Episode Id")]
		public string EpisodeId { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredFieldErrorMesssage)]
		[StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredFieldErrorMesssage)]
		[StringLength(DirectorMaxLenght, MinimumLength = DirectorMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		public string Director { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredFieldErrorMesssage)]
		[StringLength(ProducerMaxLenght, MinimumLength = ProducerMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		public string Producer { get; set; } = string.Empty;

		[Display(Name = "Release Date")]
		[RegularExpression("^(\\d{4})-(\\d{2})-(\\d{2})$")]
		public string ReleaseDate { get; set; } = string.Empty;

		[StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		[Url]
		public string? Url { get; set; }

		[Required(ErrorMessage = RequiredFieldErrorMesssage)]
		[Url]
		[StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
		public string ImageUrl { get; set; } = string.Empty;
	}
}
