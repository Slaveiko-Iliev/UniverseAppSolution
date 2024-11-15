using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static UniverseApp.Infrastructure.Common.Constants.SpecieConst;

namespace UniverseApp.Infrastructure.Data.Models
{
    public class Specie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Specie Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("Specie Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ClassificationMaxLenght)]
        [Comment("Specie Classification")]
        public string Classification { get; set; } = null!;

        [Required]
        [MaxLength(DesignationMaxLenght)]
        [Comment("Specie Designation")]
        public string Designation { get; set; } = null!;

        [MaxLength(AverageHeightMaxLenght)]
        [Comment("Specie Average Height")]
        public string? AverageHeight { get; set; }

        [MaxLength(SkinColorsMaxLenght)]
        [Comment("Specie SkinColor")]
        public string? SkinColors { get; set; }

        [MaxLength(HairColorsMaxLenght)]
        [Comment("Specie HairColor")]
        public string? HairColors { get; set; }

        [MaxLength(EyeColorsMaxLenght)]
        [Comment("Specie EyeColor")]
        public string? EyeColors { get; set; }

        [MaxLength(AverageLifespanMaxLenght)]
        [Comment("Specie Average Lifespan")]
        public string? AverageLifespan { get; set; }

        [MaxLength(HomeworldMaxLenght)]
        [Comment("Specie Homeworld")]
        public int? PlanetId { get; set; }
        [ForeignKey(nameof(PlanetId))]
        public Planet? Planet { get; set; }

        [MaxLength(LanguageMaxLenght)]
        [Comment("Specie Language")]

        public ICollection<Character> Characters { get; set; } = new HashSet<Character>();

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

        [Required]
        [MaxLength(UrlMaxLenght)]
        [Comment("Specie Url")]
        public string Url { get; set; } = null!;

        [Required]
        [Comment("Whether the Entity has been deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
