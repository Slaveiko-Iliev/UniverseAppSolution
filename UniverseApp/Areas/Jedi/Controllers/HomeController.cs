using Microsoft.AspNetCore.Mvc;

namespace UniverseApp.Areas.Jedi.Controllers
{
    public class HomeController : JediBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
