namespace UniverseApp.Areas.Jedi.Models
{
    public class UserAllViewModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool IsActive { get; set; }
        public bool IsPadawan { get; set; }
    }
}
