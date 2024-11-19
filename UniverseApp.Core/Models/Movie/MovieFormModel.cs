using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Common.Constants.MovieConst;

namespace UniverseApp.Core.Models.Movie
{
    public class MovieFormModel
    {
        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Episode Id")]
        public int? EpisodeId { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(DirectorMaxLenght)]
        public string Director { get; set; } = string.Empty;

        [Required]
        [MaxLength(ProducerMaxLenght)]
        public string Producer { get; set; } = string.Empty;

        [Display(Name = "Release Date")]
        [RegularExpression("^(\\d{4})-(\\d{2})-(\\d{2})$")]
        public string ReleaseDate { get; set; } = string.Empty;

        [RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[] Characters { get; set; } = [];

        [RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[] Planets { get; set; } = [];

        [RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[] Starships { get; set; } =  [];

        [RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[] Vehicles { get; set; } = [];

        [RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[] Species { get; set; } = [];

        [MaxLength(UrlMaxLenght)]
        [Url]
        public string? Url { get; set; }

        [Required]
        [Url]
        [MaxLength(UrlMaxLenght)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
