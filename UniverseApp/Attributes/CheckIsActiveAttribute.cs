using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Attributes
{
	public class CheckIsActiveAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
	{
		private readonly UserManager<UniverseUser> _userManager;

		public CheckIsActiveAttribute(UserManager<UniverseUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
		{
			var user = context.HttpContext.User;
			if (!user.Identity.IsAuthenticated)
			{
				context.Result = new ForbidResult();
				return;
			}

			string? userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
			var applicationUser = await _userManager.FindByIdAsync(userId ?? string.Empty);

			if (applicationUser == null || !applicationUser.IsActive)
			{
				context.Result = new ForbidResult();
			}
		}
	}
}
