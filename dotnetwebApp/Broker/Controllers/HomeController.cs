using Broker.ApplicationDB;
using Broker.Models;
using Broker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bc = BCrypt.Net.BCrypt;


namespace Broker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

       

        public IActionResult Index()
        {

            List<HomeViewModel> homeViewModels = new List<HomeViewModel>();

            var categories = this._db.Categories.ToList();

            foreach(var category in categories)
            {
                HomeViewModel model = new HomeViewModel();

                model.category = category;
                model.posts = this._db.Posts.Where(p => p.PostCategories.Any(x => x.CategoryId == category.CategoryId)).ToList();

               if(model.posts.Count != 0)
                {
                homeViewModels.Add(model);
                }
            }
        
            return View(homeViewModels);
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
       
        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult PostPage()
        {
            return View();
        }
        public IActionResult PostPageDetails()
        {
            return View();
        }
        public IActionResult SponsoredPostPage()
        {
            var SponsoredPosts = _db.Posts.Where(p => p.IsArchived == false && p.IsSponsored == true);

            return View(SponsoredPosts);
        }
        
    }
}
