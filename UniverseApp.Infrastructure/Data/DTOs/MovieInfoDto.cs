using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Data.Constants;
using static UniverseApp.Infrastructure.Data.Constants.MovieConst;

namespace UniverseApp.Infrastructure.Data.DTOs
{
    public class MovieInfoDto
    {
        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public required string Title { get; set; }

        [Required]
        [JsonPropertyName("episode_id")]
        [StringLength(DtoEpisodeIdMaxLenght, MinimumLength = DtoEpisodeIdMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public int EpisodeId { get; set; }

        [Required]
        [JsonPropertyName("opening_crawl")]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public required string Description { get; set; }

        [Required]
        [StringLength(DirectorMaxLenght, MinimumLength = DirectorMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public required string Director { get; set; }

        [Required]
        [StringLength(ProducerMaxLenght, MinimumLength = ProducerMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public required string Producer { get; set; }

        [Required]
        [JsonPropertyName("release_date")]
        public required string ReleaseDate { get; set; } // format "1977-05-25"

        public string[]? Characters { get; set; } 

        public string[]? Planets { get; set; }

        public string[]? Starships { get; set; }

        public string[]? Vehicles { get; set; }

        public string[]? Species { get; set; }

        [Required]
        [StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Url { get; set; } = null!;
    }
}
