using System.ComponentModel.DataAnnotations;
using static UniverseApp.Infrastructure.Common.Constants.General;
using static UniverseApp.Infrastructure.Common.Constants.PlanetConst;

namespace UniverseApp.Core.Models.Planet
{
    public class PlanetFormModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMesssage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Name { get; set; } = string.Empty;

        [StringLength(RotationOrbitalPeriodMaxLenght, MinimumLength = RotationOrbitalPeriodMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Display(Name = "Rotation Period")]
        public int? RotationPeriod { get; set; }

        [StringLength(RotationOrbitalPeriodMaxLenght, MinimumLength = RotationOrbitalPeriodMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Display(Name = "Orbital Period")]
        public int? OrbitalPeriod { get; set; }

        [StringLength(ClimateMaxLenght, MinimumLength = ClimateMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Climate { get; set; }

        [StringLength(GravityMaxLenght, MinimumLength = GravityMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Gravity { get; set; }

        [StringLength(TerrainMaxLenght, MinimumLength = TerrainMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Terrain { get; set; }

        [StringLength(SurfaceWaterMaxLenght, MinimumLength = SurfaceWaterMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Display(Name = "Surface Water")]
        public double? SurfaceWater { get; set; }

        [StringLength(PopulationMaxLenght, MinimumLength = PopulationMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public int? Population { get; set; }

        [StringLength(CharacterIdsMaxLenght, MinimumLength = CharacterIdsMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? CharacterIds { get; set; }

        [StringLength(MovieIdsMaxLenght, MinimumLength = MovieIdsMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? MovieIds { get; set; }

        [StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Display(Name = "Planet Url")]
        public string? Url { get; set; }
    }
}
