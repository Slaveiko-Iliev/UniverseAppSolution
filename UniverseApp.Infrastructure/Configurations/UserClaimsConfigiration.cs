using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniverseApp.Infrastructure.Configurations
{
	internal class UserClaimsConfigiration : IEntityTypeConfiguration<IdentityUserClaim<string>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
		{
			var yadaFullNameClaim = new IdentityUserClaim<string>()
			{
				Id = 1,
				UserId = "cfcc5c95-4666-4fe1-b26a-50c4016dac21",
				ClaimType = "user:fullname",
				ClaimValue = "Yoda Master"
			};

			var userFullNameClaim = new IdentityUserClaim<string>()
			{
				Id = 2,
				UserId = "18990560-1cca-49b8-b4db-5adb987559c3",
				ClaimType = "user:fullname",
				ClaimValue = "First User"
			};

			builder.HasData(yadaFullNameClaim, userFullNameClaim);
		}
	}
}
