using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.CharacterConst;

namespace UniverseApp.Infrastructure.Data.Models
{
    [Include("Movies")]
    [Include("Species")]
    [Include("Vehicles")]
    [Include("Starships")]
    [Comment("Character Entity")]
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Character Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("Character Name")]
        public string Name { get; set; } = null!;

        [Comment("Character Height")]
        public int? Height { get; set; }

        [Comment("Character Mass")]
        public int? Mass { get; set; }

        [MaxLength(HairColorMaxLenght)]
        [Comment("Character Hair Color")]
        public string? HairColor { get; set; }

        [MaxLength(SkinColorMaxLenght)]
        [Comment("Character Skin Color")]
        public string? SkinColor { get; set; }

        [MaxLength(EyeColorMaxLenght)]
        [Comment("Character Eye Color")]
        public string? EyeColor { get; set; }

        [MaxLength(BirthYearMaxLenght)]
        [Comment("Character Birth Year")]
        public string? BirthYear { get; set; }

        [MaxLength(GenderMaxLenght)]
        [Comment("Character Gender")]
        public string? Gender { get; set; }

        [Comment("Character Home Planet")]
        public int? PlanetId { get; set; }
        [ForeignKey(nameof(PlanetId))]
        public Planet? Planet { get; set; }

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

        public ICollection<Specie> Species { get; set; } = new HashSet<Specie>();

        public ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();

        public ICollection<Starship> Starships { get; set; } = new HashSet<Starship>();

        [MaxLength(UrlMaxLenght)]
        [Comment("Character Url")]
        public string? Url { get; set; } = null!;

        [Required]
        [Comment("Whether the Entity has been deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}

