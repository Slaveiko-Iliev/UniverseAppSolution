using static UniverseApp.Infrastructure.Constants.JediConstants;

namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsYoda(this ClaimsPrincipal user)
            => user.IsInRole(JediRoleName);
    }
}
