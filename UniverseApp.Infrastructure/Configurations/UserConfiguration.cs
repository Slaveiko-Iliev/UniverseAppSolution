using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Infrastructure.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<UniverseUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UniverseUser> builder)
        {
            var hash = new PasswordHasher<UniverseUser>();

            var user = new UniverseUser
            {
                Id = "18990560-1cca-49b8-b4db-5adb987559c3",
                Email = "user@mail.com",
                NormalizedEmail = "user@mail.com".ToUpper(),
                UserName = "user@mail.com",
                NormalizedUserName = "user@mail.com".ToUpper(),
                FirstName = "First",
                LastName = "User"
            };

            user.PasswordHash = hash.HashPassword(user, "aA@123");

            builder.HasData(user);
        }
    }
}
