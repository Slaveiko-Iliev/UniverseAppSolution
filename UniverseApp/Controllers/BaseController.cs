using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UniverseApp.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
