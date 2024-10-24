using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverseApp.Infrastructure.Data.Models
{
	[Comment("CharactersMovies Entity")]
	public class CharacterMovie
	{
		[Key]
		[Comment("Character Identifier")]
		public int CharacterId { get; set; }
		[ForeignKey(nameof(CharacterId))]
		public Character Character { get; set; } = null!;

		[Key]
		[Comment("Movie Identifier")]
		public int MovieId { get; set; }
		[ForeignKey(nameof(MovieId))]
		public Movie Movie { get; set; } = null!;
	}
}
