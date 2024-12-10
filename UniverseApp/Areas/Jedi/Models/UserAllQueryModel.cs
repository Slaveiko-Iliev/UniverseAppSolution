using System.ComponentModel.DataAnnotations;

namespace UniverseApp.Areas.Jedi.Models
{
    public class UserAllQueryModel
    {
        public const int UsersPerPage = 10;

        [Display(Name = "Is the user active")]
        public string? SearchIsActive { get; set; } = string.Empty;

        [Display(Name = "Is the user padawan")]
        public string? SearchIsPadawan { get; set; } = string.Empty;

        public int CurrentPage { get; set; } = 1;

        public int TotalUsersCount { get; set; }

        public IEnumerable<UserAllViewModel> Users { get; set; } = new List<UserAllViewModel>();
    }
}
