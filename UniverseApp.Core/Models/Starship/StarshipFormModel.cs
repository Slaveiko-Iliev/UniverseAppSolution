using System.ComponentModel.DataAnnotations;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.General;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.StarshipConst;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.VehicleConst;
namespace UniverseApp.Core.Models.Starship
{
    public class StarshipFormModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMesssage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Name { get; set; } = string.Empty;

        [StringLength(ModelMaxLenght, MinimumLength = ModelMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? StarshipModel { get; set; }

        [StringLength(ManufacturerMaxLenght, MinimumLength = ManufacturerMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Manufacturer { get; set; }

        [StringLength(CostInCreditsMaxLenght, MinimumLength = CostInCreditsMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Display(Name = "Cost in credits")]
        public string? CostInCredits { get; set; }

        [StringLength(LengthMaxLenght, MinimumLength = LengthMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Length { get; set; }

        [StringLength(MaxAtmospheringSpeedMaxLenght, MinimumLength = MaxAtmospheringSpeedMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Display(Name = "Max atmosphering speed")]
        public string? MaxAtmospheringSpeed { get; set; }

        [StringLength(CrewMaxLenght, MinimumLength = CrewMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Crew { get; set; }

        [StringLength(PassengersMaxLenght, MinimumLength = PassengersMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Passengers { get; set; }

        [StringLength(CargoCapacityMaxLenght, MinimumLength = CargoCapacityMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Display(Name = "Cargo capacity")]
        public string? CargoCapacity { get; set; }

        [StringLength(ConsumablesMaxLenght, MinimumLength = ConsumablesMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Consumables { get; set; }

        [StringLength(ClassMaxLenght, MinimumLength = ClassMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Display(Name = "Vehicle class")]
        public string? Class { get; set; }

        [StringLength(HyperdriveRatingMaxLenght, MinimumLength = HyperdriveRatingMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Display(Name = "Hyperdrive rating")]
        public string? HyperdriveRating { get; set; }

        [StringLength(MGLTMaxLenght, MinimumLength = MGLTMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Display(Name = "MGLT")]
        public string? MGLT { get; set; }
    }
}
