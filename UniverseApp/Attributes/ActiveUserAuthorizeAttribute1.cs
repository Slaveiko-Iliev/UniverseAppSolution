namespace UniverseApp.Attributes
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;
	using System;
	using System.Security.Claims;
	using System.Threading.Tasks;
	using UniverseApp.Infrastructure.Data;

	public class ActiveUserAuthorizeAttribute1 : AuthorizeAttribute, IAsyncAuthorizationFilter
	{
		private readonly UniverseDbContext _context;

		public ActiveUserAuthorizeAttribute1(UniverseDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
		{
			var user = context.HttpContext.User;
			if (!user.Identity.IsAuthenticated)
			{
				context.Result = new ForbidResult();
				return;
			}

			var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
			var applicationUser = await _context.Users.FindAsync(userId);

			if (applicationUser == null || !applicationUser.IsActive)
			{
				context.Result = new ForbidResult();
			}
		}
	}

}
