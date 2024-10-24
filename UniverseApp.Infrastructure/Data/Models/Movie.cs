using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static UniverseApp.Infrastructure.Data.EntityConstants.MovieConst;

namespace UniverseApp.Infrastructure.Data.Models
{
    [Comment("Movie Entity")]
    public class Movie
    {
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Movie Identifier")]
		public int Id { get; set; }

		[Required]
		[MaxLength(TitleMaxLenght)]
		[Comment("Movie Title")]
		public required string Title { get; set; }

        [Required]
		[Comment("Movie Episode Identifier")]
        public int EpisodeId { get; set; }

		[Required]
		[MaxLength(DescriptionMaxLenght)]
		[Comment("Movie Description")]
		public required string Description { get; set; }

		[Required]
		[MaxLength(DirectorMaxLenght)]
		[Comment("Movie Director")]
		public required string Director { get; set; } // ToDo: Create Director Entity

		[Required]
		[MaxLength(ProducerMaxLenght)]
		[Comment("Movie Producer")]
		public required string Producer { get; set; } // ToDo: Create Producer Entity "Gary Kurtz, Rick McCallum"

		[Comment("Movie Release Date")]
		public DateTime ReleaseDate { get; set; } // format "1977-05-25"

		public ICollection<CharacterMovie> CharactersMovies { get; set; } = new HashSet<CharacterMovie>();
	}
}

	//"planets": [],
	//"starships": [],
	//"vehicles": [],
	//"species": [],
	//"created": "2014-12-10T14:23:31.880000Z",
	//"edited": "2014-12-20T19:49:45.256000Z",
	//"url": "https://swapi.dev/api/films/1/"