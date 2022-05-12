using BrokerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrokerApp.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PostPageCreate()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult PostPageCreate(PostViewModel postView)
        {
            if (postView.Titulli == "")
            {
                return BadRequest();
            }
            if (postView.Image == null)
            {
                return BadRequest();
            }
            if (postView.Descritption == "")
            {
                return BadRequest();
            }
            if (postView.Price <= 0)
            {
                return BadRequest();
            }
            return View();
        }

    }
}
