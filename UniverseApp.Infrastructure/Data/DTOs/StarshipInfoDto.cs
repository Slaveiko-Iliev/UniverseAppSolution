using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.General;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.StarshipConst;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.VehicleConst;

namespace UniverseApp.Infrastructure.Data.DTOs
{
    internal class StarshipInfoDto
    {
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Name { get; set; } = null!;

        [StringLength(ModelMaxLenght, MinimumLength = ModelMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Model { get; set; }

        [StringLength(ManufacturerMaxLenght, MinimumLength = ManufacturerMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Manufacturer { get; set; }

        [JsonPropertyName("cost_in_credits")]
        [StringLength(CostInCreditsMaxLenght, MinimumLength = CostInCreditsMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? CostInCredits { get; set; }

        [StringLength(LengthMaxLenght, MinimumLength = LengthMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Length { get; set; }

        [JsonPropertyName("max_atmosphering_speed")]
        [StringLength(MaxAtmospheringSpeedMaxLenght, MinimumLength = MaxAtmospheringSpeedMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? MaxAtmospheringSpeed { get; set; }

        [StringLength(CrewMaxLenght, MinimumLength = CrewMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Crew { get; set; }

        [StringLength(PassengersMaxLenght, MinimumLength = PassengersMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Passengers { get; set; }

        [JsonPropertyName("cargo_capacity")]
        [StringLength(CargoCapacityMaxLenght, MinimumLength = CargoCapacityMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? CargoCapacity { get; set; }

        [StringLength(ConsumablesMaxLenght, MinimumLength = ConsumablesMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Consumables { get; set; }

        [JsonPropertyName("vehicle_class")]
        [StringLength(ClassMaxLenght, MinimumLength = ClassMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Class { get; set; }

        public string[]? Pilots { get; set; }

        [JsonPropertyName("films")]
        public string[]? Movies { get; set; }

        [Required]
        [StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Url { get; set; } = null!;

        [JsonPropertyName("hyperdrive_rating")]
        [StringLength(HyperdriveRatingMaxLenght, MinimumLength = HyperdriveRatingMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? HyperdriveRating { get; set; }

        [StringLength(MGLTMaxLenght, MinimumLength = MGLTMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? MGLT { get; set; }
    }
}
