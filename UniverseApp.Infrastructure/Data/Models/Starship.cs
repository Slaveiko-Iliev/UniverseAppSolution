using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static UniverseApp.Infrastructure.Data.Constants.StarshipConst;

namespace UniverseApp.Infrastructure.Data.Models
{
    public class Starship : Vehicle
    {
        [MaxLength(HyperdriveRatingMaxLenght)]
        [Comment("Starship Hyperdrive Rating")]
        public double? HyperdriveRating { get; set; }

        [MaxLength(MGLTMaxLenght)]
        [Comment("Starship MGLT")]
        public int? MGLT { get; set; }
    }
}
