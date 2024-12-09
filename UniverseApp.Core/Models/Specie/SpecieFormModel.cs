using System.ComponentModel.DataAnnotations;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.General;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.SpecieConst;

namespace UniverseApp.Core.Models.Specie
{
    public class SpecieFormModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMesssage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMesssage)]
        [StringLength(ClassificationMaxLenght, MinimumLength = ClassificationMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Classification { get; set; } = null!;

        [Required(ErrorMessage = RequiredFieldErrorMesssage)]
        [StringLength(DesignationMaxLenght, MinimumLength = DesignationMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Designation { get; set; } = null!;

        [StringLength(AverageHeightMaxLenght, MinimumLength = AverageHeightMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? AverageHeight { get; set; }

        [StringLength(SkinColorsMaxLenght, MinimumLength = SkinColorsMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? SkinColor { get; set; }

        [StringLength(HairColorsMaxLenght, MinimumLength = HairColorsMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? HairColor { get; set; }

        [StringLength(EyeColorsMaxLenght, MinimumLength = EyeColorsMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? EyeColor { get; set; }

        [StringLength(AverageLifespanMaxLenght, MinimumLength = AverageLifespanMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? AverageLifespan { get; set; }

        [StringLength(LanguageMaxLenght, MinimumLength = LanguageMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Language { get; set; }

        [StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Url { get; set; }
    }
}
