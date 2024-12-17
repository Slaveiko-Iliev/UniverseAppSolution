using System.ComponentModel.DataAnnotations;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.General;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.PlanetConst;

namespace UniverseApp.Core.Models.Planet
{
    public class PlanetFormModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMesssage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Name { get; set; } = string.Empty;

        [StringLength(RotationOrbitalPeriodMaxLenght, MinimumLength = RotationOrbitalPeriodMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [RegularExpression(@"^\d*$", ErrorMessage = NumberFieldErrorMesssage)]
        [Display(Name = "Rotation Period")]
        public string? RotationPeriod { get; set; }

        [StringLength(RotationOrbitalPeriodMaxLenght, MinimumLength = RotationOrbitalPeriodMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [RegularExpression(@"^\d*$", ErrorMessage = NumberFieldErrorMesssage)]
        [Display(Name = "Orbital Period")]
        public string? OrbitalPeriod { get; set; }

        [StringLength(ClimateMaxLenght, MinimumLength = ClimateMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Climate { get; set; }

        [StringLength(GravityMaxLenght, MinimumLength = GravityMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Gravity { get; set; }

        [StringLength(TerrainMaxLenght, MinimumLength = TerrainMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Terrain { get; set; }

        [StringLength(SurfaceWaterMaxLenght, MinimumLength = SurfaceWaterMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [RegularExpression(@"^\d*,?\d*$", ErrorMessage = DecimalNumberFieldErrorMesssage)]
        [Display(Name = "Surface Water")]
        public string? SurfaceWater { get; set; }

        [StringLength(PopulationMaxLenght, MinimumLength = PopulationMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [RegularExpression(@"^\d*$", ErrorMessage = NumberFieldErrorMesssage)]
        public string? Population { get; set; }

        [StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Display(Name = "Planet Url")]
        public string? Url { get; set; }
    }
}
