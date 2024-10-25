using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Data.Constants.PlanetConst;
using static UniverseApp.Infrastructure.Data.Constants.General;

namespace UniverseApp.Infrastructure.Data.DTOs
{
    internal class PlanetInfoDto
    {
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal required string Name { get; set; }

        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal string? RotationPeriod { get; set; }

        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal string? OrbitalPeriod { get; set; }

        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal string? Climate { get; set; }

        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal string? Gravity { get; set; }

        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal string? Terrain { get; set; }

        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal string? SurfaceWater { get; set; }

        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal string? Population { get; set; }

        [MaxLength(ResidentsMaxLenght)]
        internal string[]? Residents { get; set; }

        [MaxLength(FilmsMaxLenght)]
        internal string[]? Films { get; set; }

        [Required]
        [Url]
        [StringLength(UrlMaxLenght, MinimumLength = UrlMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        internal required string Url { get; set; }
    }
}
