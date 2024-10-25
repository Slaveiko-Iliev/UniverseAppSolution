using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UniverseApp.Infrastructure.Data.Constants.General;
using static UniverseApp.Infrastructure.Data.Constants.SpecieConst;

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
        public string Classification { get; set; } = null!; //is nullable?

        [Required]
        [MaxLength(DesignationMaxLenght)]
        [Comment("Specie Designation")]
        public string Designation { get; set; } = null!; //is nullable?

        [MaxLength(AverageHeightMaxLenght)]
        [Comment("Specie Average Height")]
        public string? AverageHeight { get; set; } //is nullable?

        [MaxLength(SkinColorsMaxLenght)]
        [Comment("Specie SkinColor")]
        public string? SkinColors { get; set; } //is nullable?

        [MaxLength(HairColorsMaxLenght)]
        [Comment("Specie HairColor")]
        public string? HairColors { get; set; } //is nullable?

        [MaxLength(EyeColorsMaxLenght)]
        [Comment("Specie EyeColor")]
        public string? EyeColors { get; set; } //is nullable?

        [MaxLength(AverageLifespanMaxLenght)]
        [Comment("Specie Average Lifespan")]
        public string? AverageLifespan { get; set; } //is nullable?

        [MaxLength(HomeworldMaxLenght)]
        [Comment("Specie Homeworld")]
        public string? Homeworld { get; set; } //is nullable?

        [MaxLength(LanguageMaxLenght)]
        [Comment("Specie Language")]
        public string? Language { get; set; } //is nullable?

        public ICollection<Character> Characters { get; set; } = new HashSet<Character>();

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

        [Required]
        [MaxLength(UrlMaxLenght)]
        [Comment("Specie Url")]
        public string Url { get; set; } = null!;
    }
}
