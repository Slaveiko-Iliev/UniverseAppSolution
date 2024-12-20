﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniverseApp.Infrastructure.Models;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.MovieConst;

namespace UniverseApp.Infrastructure.Data.Models
{
    [Include("Characters")]
    [Include("Planets")]
    [Include("Starships")]
    [Include("Vehicles")]
    [Include("Species")]
    [Comment("Movie Entity")]
    public class Movie : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Movie Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        [Comment("Movie Title")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(EpisodeIdMaxLenght)]
        [Comment("Movie Episode Identifier")]
        public string EpisodeId { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        [Comment("Movie Description")]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(DirectorMaxLenght)]
        [Comment("Movie Director")]
        public string Director { get; set; } = null!;

        [Required]
        [MaxLength(ProducerMaxLenght)]
        [Comment("Movie Producer")]
        public string Producer { get; set; } = null!;

        [Comment("Movie Release Date")]
        public DateTime ReleaseDate { get; set; }

        public ICollection<Character> Characters { get; set; } = new HashSet<Character>();

        public ICollection<Planet> Planets { get; set; } = new HashSet<Planet>();

        public ICollection<Starship> Starships { get; set; } = new HashSet<Starship>();

        public ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();

        public ICollection<Specie> Species { get; set; } = new HashSet<Specie>();

        [MaxLength(UrlMaxLenght)]
        public string? Url { get; set; }

        [MaxLength(UrlMaxLenght)]
        [Comment("Movie Image Url")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Whether the Entity has been deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}