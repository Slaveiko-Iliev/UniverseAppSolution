using Microsoft.AspNetCore.Identity;
using static UniverseApp.Infrastructure.Constants.JediConstants;

namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsYoda(this ClaimsPrincipal user, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(YodaRoleName).Result)
            {
                return false;
            }

            return user.IsInRole(YodaRoleName);
        }

        public static bool IsPadawan(this ClaimsPrincipal user, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(PadawanRoleName).Result)
            {
                return false;
            }

            return user.IsInRole(PadawanRoleName);
        }
    }
}
