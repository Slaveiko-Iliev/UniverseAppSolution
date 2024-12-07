using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static UniverseApp.Infrastructure.Constants.JediConstants;

namespace UniverseApp.Areas.Jedi.Controllers
{
    [Area(JediAreaName)]
    [Authorize(Roles = JediRoleName)]
    public class JediBaseController : Controller
    {

    }
}
