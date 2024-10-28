using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static UniverseApp.Infrastructure.Data.Constants.MovieConst;

namespace UniverseApp.Infrastructure.Data.Models
{
    [Comment("Movie Entity")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Movie Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        [Comment("Movie Title")]
        public string Title { get; set; } = null!;

        [Required]
        [Comment("Movie Episode Identifier")]
        public int EpisodeId { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        [Comment("Movie Description")]
        public required string Description { get; set; }

        [Required]
        [MaxLength(DirectorMaxLenght)]
        [Comment("Movie Director")]
        public required string Director { get; set; }

        [Required]
        [MaxLength(ProducerMaxLenght)]
        [Comment("Movie Producer")]
        public required string Producer { get; set; }

        [Comment("Movie Release Date")]
        public DateTime ReleaseDate { get; set; } // format "1977-05-25"

        public ICollection<Character> Characters { get; set; } = new HashSet<Character>();

        public ICollection<Planet> Planets { get; set; } = new HashSet<Planet>();

        public ICollection<Starship> Starships { get; set; } = new HashSet<Starship>();

        public ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();

        public ICollection<Specie> Species { get; set; } = new HashSet<Specie>();

        [Required]
        [MaxLength(UrlMaxLenght)]
        public string Url { get; set; } = null!;

        [Required]
        [Comment("Whether the Entity has been deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}