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
			var yodaRole = new IdentityRole
			{
				Id = "6468123d-a641-4305-9a52-533361297ed3",
				Name = YodaRoleName,
				NormalizedName = YodaRoleName.ToUpper()
			};

			var padawanRole = new IdentityRole
			{
				Id = "234e651b-2617-450d-838e-b8a6d072b35c",
				Name = PadawanRoleName,
				NormalizedName = PadawanRoleName.ToUpper()
			};

			builder.HasData(yodaRole, padawanRole);
		}
	}
}
