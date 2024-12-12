using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UniverseApp.Controllers
{
	[Authorize]
	[ActiveUserAuthorizeAttribute]
	public class BaseController : Controller
	{

	}
}
