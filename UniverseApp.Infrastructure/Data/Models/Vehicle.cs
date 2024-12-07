using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.VehicleConst;

namespace UniverseApp.Infrastructure.Data.Models
{
    [Include("Characters")]
    [Include("Movies")]
    [Comment("Vehicle Entity")]
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Vehicle Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("Vehicle Name")]
        public string Name { get; set; } = null!;

        [MaxLength(ModelMaxLenght)]
        [Comment("Vehicle Model")]
        public string? Model { get; set; }

        [MaxLength(ManufacturerMaxLenght)]
        [Comment("Vehicle Manufacturer")]
        public string? Manufacturer { get; set; }

        [MaxLength(CostInCreditsMaxLenght)]
        [Comment("Vehicle Cost In Credits")]
        public int? CostInCredits { get; set; }

        [MaxLength(LengthMaxLenght)]
        [Comment("Vehicle Length")]
        public double? Length { get; set; }

        [MaxLength(MaxAtmospheringSpeedMaxLenght)]
        [Comment("Vehicle Max Atmosphering Speed")]
        public int? MaxAtmospheringSpeed { get; set; }

        [MaxLength(CrewMaxLenght)]
        [Comment("Vehicle Crew")]
        public int? Crew { get; set; }

        [MaxLength(PassengersMaxLenght)]
        [Comment("Vehicle Passengers")]
        public int? Passengers { get; set; }

        [MaxLength(CargoCapacityMaxLenght)]
        [Comment("Vehicle Cargo Capacity")]
        public int? CargoCapacity { get; set; }

        [MaxLength(ConsumablesMaxLenght)]
        [Comment("Vehicle Consumables")]
        public string? Consumables { get; set; }

        [MaxLength(ClassMaxLenght)]
        [Comment("Vehicle Class")]
        public string? Class { get; set; }

        public ICollection<Character> Characters { get; set; } = new HashSet<Character>();

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

        [MaxLength(UrlMaxLenght)]
        [Comment("Vehicle URL")]
        public string? Url { get; set; } = null!;

        [Required]
        [Comment("Whether the Entity has been deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
