using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Attributes
{
	public class ActiveUserAuthorizationFilter : IAsyncAuthorizationFilter
	{
		private readonly UserManager<UniverseUser> _userManager;
		private readonly bool _allowAnonymous;

		public ActiveUserAuthorizationFilter(UserManager<UniverseUser> userManager, bool allowAnonymous)
		{
			_userManager = userManager;
			_allowAnonymous = allowAnonymous;
		}

		public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
		{
			var user = context.HttpContext.User;

			if (_allowAnonymous && !user.Identity.IsAuthenticated)
			{
				return;
			}

			if (!user.Identity.IsAuthenticated)
			{
				context.Result = new ForbidResult();
				return;
			}

			var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
			var applicationUser = await _userManager.FindByIdAsync(userId);

			if (applicationUser == null || !applicationUser.IsActive)
			{
				context.Result = new ForbidResult();
			}
		}
	}

}
