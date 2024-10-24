﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UniverseApp.Infrastructure.Data.Constants;
using static UniverseApp.Infrastructure.Data.Constants.PlanetConst;

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
        [Comment("Planet Name")]
        public string Name { get; set; } = null!;

        [MaxLength(NameMaxLenght)]
        [Comment("Rotation Period of Planet")]
        public int? RotationPeriod { get; set; }

        [MaxLength(NameMaxLenght)]
        [Comment("Orbital Period of Planet")]
        public int? OrbitalPeriod { get; set; }

        [MaxLength(NameMaxLenght)]
        [Comment("Climate of Planet")]
        public string[]? Climate { get; set; }

        [MaxLength(NameMaxLenght)]
        [Comment("Gravity of Planet")]
        public string? Gravity { get; set; }

        [MaxLength(NameMaxLenght)]
        [Comment("Terrain of Planet")]
        public string[]? Terrain { get; set; }

        [MaxLength(NameMaxLenght)]
        [Column(TypeName = "decimal(5, 2)")]
        [Comment("Surface Water of Planet")]
        public double? SurfaceWater { get; set; }

        [MaxLength(NameMaxLenght)]
        [Comment("Population of Planet")]
        public int? Population { get; set; }

        public ICollection<Character> Character { get; set; } = new List<Character>();

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();

        [Required]
        [MaxLength(UrlMaxLenght)]
        [Comment("Planet Url")]
        public string Url { get; set; } = null;

    }
}
