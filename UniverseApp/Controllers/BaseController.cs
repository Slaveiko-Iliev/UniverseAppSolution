using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniverseApp.Attributes;

namespace UniverseApp.Controllers
{
	[Authorize]
	[ActiveUserAuthorize]
	public class BaseController : Controller
	{

	}
}
