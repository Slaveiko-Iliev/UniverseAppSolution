using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverseApp.Core.Models.Movie
{
    public class MovieDetailsViewModel : MovieFormModel
    {
        public int Id { get; set; }

        //[RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[]? Characters { get; set; } = [];

        //[RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[]? Planets { get; set; } = [];

        //[RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[]? Starships { get; set; } = [];

        //[RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[]? Vehicles { get; set; } = [];

        //[RegularExpression("(?:^(\\d+)(, \\d+)*$)")]
        public int[]? Species { get; set; } = [];
    }
}
