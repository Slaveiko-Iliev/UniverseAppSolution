using Microsoft.AspNetCore.Mvc;

namespace UniverseApp.Attributes
{
	public class ActiveUserAuthorizeAttribute : TypeFilterAttribute
	{
		public ActiveUserAuthorizeAttribute() : base(typeof(ActiveUserAuthorizationFilter))
		{
		}
	}

}
