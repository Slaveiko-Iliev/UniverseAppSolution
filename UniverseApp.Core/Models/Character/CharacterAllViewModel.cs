using System.ComponentModel.DataAnnotations.Schema;

namespace UniverseApp.Core.Models.Character

{
	public class CharacterAllViewModel : CharacterFormModel
	{
		public int Id { get; set; }
		public string? ImageUrl { get; set; }

		public int? PlanetId { get; set; }
		[ForeignKey(nameof(PlanetId))]
		public UniverseApp.Infrastructure.Data.Models.Planet? Planet { get; set; }
	}
}
