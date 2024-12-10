using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static UniverseApp.Infrastructure.Constants.UniverseUserConstants;

namespace UniverseApp.Infrastructure.Data.Models
{
    public class UniverseUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [Comment("Is the user active")]
        public bool IsActive { get; set; } = true;
    }
}
