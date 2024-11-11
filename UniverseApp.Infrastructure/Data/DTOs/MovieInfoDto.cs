using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Data.Constants.General;
using static UniverseApp.Infrastructure.Data.Constants.MovieConst;

namespace UniverseApp.Infrastructure.Data.DTOs
{
    internal class MovieInfoDto
    {
        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal required string Title { get; set; }

        [Required]
        [JsonPropertyName("episode_id")]
        [StringLength(DtoEpisodeIdMaxLenght, MinimumLength = DtoEpisodeIdMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal required string EpisodeId { get; set; }

        [Required]
        [JsonPropertyName("opening_crawl")]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal required string Description { get; set; }

        [Required]
        [StringLength(DirectorMaxLenght, MinimumLength = DirectorMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal required string Director { get; set; }

        [Required]
        [StringLength(ProducerMaxLenght, MinimumLength = ProducerMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal required string Producer { get; set; }

        [Required]
        [JsonPropertyName("release_date")]
        internal required string ReleaseDate { get; set; } // format "1977-05-25"

        internal string[]? Characters { get; set; } 

        internal string[]? Planets { get; set; }

        internal string[]? Starships { get; set; }

        internal string[]? Vehicles { get; set; }

        internal string[]? Species { get; set; }

        [Required]
        [StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Url]
        internal string Url { get; set; } = null!;
    }
}
