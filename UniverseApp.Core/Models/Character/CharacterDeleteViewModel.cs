namespace UniverseApp.Core.Models.Character
{
	public class CharacterDeleteViewModel
	{
		public int Id { get; set; }

		public required string Name { get; set; }

		public string? Height { get; set; }

		public string? BirthYear { get; set; }
	}
}
