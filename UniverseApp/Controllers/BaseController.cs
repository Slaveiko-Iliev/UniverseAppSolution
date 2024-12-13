using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UniverseApp.Controllers
{
	[Authorize]
	[ActiveUserAuthorize]
	public class BaseController : Controller
	{

	}
}
