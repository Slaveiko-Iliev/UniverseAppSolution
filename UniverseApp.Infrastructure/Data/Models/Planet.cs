using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UniverseApp.Infrastructure.Data.EntityConstants;
using static UniverseApp.Infrastructure.Data.EntityConstants.PlanetConst;

namespace UniverseApp.Infrastructure.Data.Models
{
    public class Planet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Movie Identifier")]

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public required string Name { get; set; }

        [MaxLength(NameMaxLenght)]
        public int? RotationPeriod { get; set; }

        [MaxLength(NameMaxLenght)]
        public int? OrbitalPeriod { get; set; }

        [MaxLength(NameMaxLenght)]
        public string[]? Climate { get; set; }

        [MaxLength(NameMaxLenght)]
        public string? Gravity { get; set; }

        [MaxLength(NameMaxLenght)]
        public string[]? Terrain { get; set; }

        [MaxLength(NameMaxLenght)]
        [Column(TypeName = "decimal(5, 2)")]
        public double? SurfaceWater { get; set; }

        [MaxLength(NameMaxLenght)]
        public int? Population { get; set; }

        public ICollection<Character> Character { get; set; } = new List<Character>();

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();

        [Required]
        [Url]
        [MaxLength(UrlMaxLenght)]
        public required string Url { get; set; }

    }
}
