
using Broker.Models;
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
            if (postView.Title == "")
            {
                return BadRequest();
            }
            if (postView.image == null)
            {
                return BadRequest();
            }
            if (postView.Description == "")
            {
                return BadRequest();
            }
            return View();
        }

    }
}
