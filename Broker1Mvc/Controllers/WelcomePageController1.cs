using Microsoft.AspNetCore.Mvc;

namespace Broker1Mvc.Controllers
{
    public class WelcomePageController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
