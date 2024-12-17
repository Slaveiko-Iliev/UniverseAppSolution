using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.General;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.SpecieConst;

namespace UniverseApp.Infrastructure.Data.DTOs
{
    public class SpecieInfoDto
    {
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public required string Name { get; set; }

        [Required]
        [StringLength(ClassificationMaxLenght, MinimumLength = ClassificationMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Classification { get; set; } = null!;

        [Required]
        [StringLength(DesignationMaxLenght, MinimumLength = DesignationMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Designation { get; set; } = null!;

        [StringLength(AverageHeightMaxLenght, MinimumLength = AverageHeightMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("average_height")]
        public string? AverageHeight { get; set; }

        [StringLength(SkinColorsMaxLenght, MinimumLength = SkinColorsMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("skin_colors")]
        public string? SkinColors { get; set; }

        [StringLength(HairColorsMaxLenght, MinimumLength = HairColorsMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("hair_colors")]
        public string? HairColors { get; set; }

        [StringLength(EyeColorsMaxLenght, MinimumLength = EyeColorsMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("eye_colors")]
        public string? EyeColors { get; set; }

        [StringLength(AverageLifespanMaxLenght, MinimumLength = AverageLifespanMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("average_lifespan")]
        public string? AverageLifespan { get; set; }

        [StringLength(HomeworldMaxLenght, MinimumLength = HomeworldMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("homeworld")]
        public string? PlanetId { get; set; }

        [StringLength(LanguageMaxLenght, MinimumLength = LanguageMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Language { get; set; }

        [JsonPropertyName("people")]
        public string[]? Characters { get; set; }

        [JsonPropertyName("films")]
        public string[]? Movies { get; set; }

        [Required]
        [StringLength(UrlMaxLenght)]
        public required string Url { get; set; }
    }
}
