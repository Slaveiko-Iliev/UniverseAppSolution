using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static UniverseApp.Infrastructure.Constants.JediConstants;

namespace UniverseApp.Infrastructure.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            string roleName = JediRoleName;



            var adminRole = new IdentityRole
            {
                Id = "6468123d-a641-4305-9a52-533361297ed3",
                Name = roleName,
                NormalizedName = roleName.ToUpper()
            };

            builder.HasData(adminRole);
        }
    }
}
