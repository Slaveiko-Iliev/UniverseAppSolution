using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static UniverseApp.Infrastructure.Common.Constants.General;
using static UniverseApp.Infrastructure.Common.Constants.PlanetConst;

namespace UniverseApp.Infrastructure.Data.DTOs
{
    public class PlanetInfoDto
    {
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public required string Name { get; set; }

        [StringLength(RotationOrbitalPeriodMaxLenght, MinimumLength = RotationOrbitalPeriodMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("rotation_period")]
        public string? RotationPeriod { get; set; }

        [StringLength(RotationOrbitalPeriodMaxLenght, MinimumLength = RotationOrbitalPeriodMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("orbital_period")]
        public string? OrbitalPeriod { get; set; }

        [StringLength(DiameterMaxLenght, MinimumLength = DiameterMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Diameter { get; set; }

        [StringLength(ClimateMaxLenght, MinimumLength = ClimateMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Climate { get; set; }

        [StringLength(GravityMaxLenght, MinimumLength = GravityMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Gravity { get; set; }

        [StringLength(TerrainMaxLenght, MinimumLength = TerrainMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Terrain { get; set; }

        [StringLength(SurfaceWaterMaxLenght, MinimumLength = SurfaceWaterMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("surface_water")]
        public string? SurfaceWater { get; set; }

        [StringLength(PopulationMaxLenght, MinimumLength = PopulationMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Population { get; set; }

        [MaxLength(FilmsMaxLenght)]
        public string[]? Films { get; set; }

        [Required]
        [Url]
        [StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public required string Url { get; set; }
    }
}
