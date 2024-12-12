using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using UniverseApp.Infrastructure.Data.Models;

public class ActiveUserAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
{
	public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
	{
		var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
		if (allowAnonymous)
		{
			return;
		}

		var user = context.HttpContext.User;
		if (!user.Identity.IsAuthenticated)
		{
			context.Result = new ForbidResult();
			return;
		}

		var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
		var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<UniverseUser>>();
		var applicationUser = await userManager.FindByIdAsync(userId);

		if (applicationUser == null || !applicationUser.IsActive)
		{
			context.Result = new ForbidResult();
		}
	}
}