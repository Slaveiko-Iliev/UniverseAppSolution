using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverseApp.Infrastructure.Data.Models
{
	public class Character
	{
		public int Id { get; set; }

		public ICollection<CharacterMovie> CharactersMovies { get; set; } = new HashSet<CharacterMovie>();
	}
}

