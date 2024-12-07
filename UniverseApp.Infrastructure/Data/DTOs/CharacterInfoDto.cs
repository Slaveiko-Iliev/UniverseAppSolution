using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.CharacterConst;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.General;
using System.Text.Json.Serialization;

namespace UniverseApp.Infrastructure.Data.DTOs
{
    internal class CharacterInfoDto
    {
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public required string Name { get; set; }

        [StringLength(HeightMaxLenght, MinimumLength = HeightMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Height { get; set; }

        [StringLength(MassMaxLenght, MinimumLength = MassMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Mass { get; set; }

        [StringLength(HairColorMaxLenght, MinimumLength = HairColorMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("hair_color")]
        public string? HairColor { get; set; } // is nullable?

        [StringLength(SkinColorMaxLenght, MinimumLength = SkinColorMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("skin_color")]
        public string? SkinColor { get; set; } // is nullable?

        [StringLength(EyeColorMaxLenght, MinimumLength = EyeColorMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("eye_color")]
        public string? EyeColor { get; set; } // is nullable?

        [StringLength(BirthYearMaxLenght, MinimumLength = BirthYearMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("birth_year")]
        public string? BirthYear { get; set; } // is nullable?

        [StringLength(GenderMaxLenght, MinimumLength = GenderMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Gender { get; set; }

        [StringLength(HomeworldMaxLenght, MinimumLength = HomeworldMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [JsonPropertyName("homeworld")]
        public string? PlanetId { get; set; }

        public string[]? Movies { get; set; }

        public string[]? Species { get; set; }

        public string[]? Vehicles { get; set; }

        public string[]? Starships { get; set; }

        [Required]
        [StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        [Url]
        public required string Url { get; set; }
    }
}
