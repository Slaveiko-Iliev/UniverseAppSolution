using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniverseApp.Infrastructure.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            var userRoles = new IdentityUserRole<string>()
            {
                UserId = "cfcc5c95-4666-4fe1-b26a-50c4016dac21",
                RoleId = "6468123d-a641-4305-9a52-533361297ed3"
            };

            builder.HasData(userRoles);
        }
    }
}
