using Microsoft.AspNetCore.Mvc;

namespace BrokerAppMVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
