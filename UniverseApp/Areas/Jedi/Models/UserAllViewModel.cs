namespace UniverseApp.Areas.Jedi.Models
{
	public class UserAllViewModel
	{
		public required string Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public bool IsActive { get; set; }
		public bool IsPadawan { get; set; }
	}
}
