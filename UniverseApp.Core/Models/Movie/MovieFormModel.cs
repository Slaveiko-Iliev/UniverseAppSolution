using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Common.Constants.MovieConst;
using static UniverseApp.Infrastructure.Common.Constants.General;

namespace UniverseApp.Core.Models.Movie
{
    public class MovieFormModel
    {
        [Required(ErrorMessage = RequiredField)]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(EpisodeIdMaxLenght, MinimumLength = EpisodeIdMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Display(Name = "Episode Id")]
        public string EpisodeId { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DirectorMaxLenght, MinimumLength = DirectorMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(ProducerMaxLenght, MinimumLength = ProducerMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string Producer { get; set; } = string.Empty;

        [Display(Name = "Release Date")]
        //[RegularExpression("^(\\d{4})-(\\d{2})-(\\d{2})$")]
        public string ReleaseDate { get; set; } = string.Empty;

        //[RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[]? Characters { get; set; } = [];

        //[RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[]? Planets { get; set; } = [];

        //[RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[]? Starships { get; set; } =  [];

        //[RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[]? Vehicles { get; set; } = [];

        //[RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[]? Species { get; set; } = [];

        [StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Url]
        public string? Url { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Url]
        [StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
