using AutoMapper;
using Broker.ApplicationDB;
using Broker.Models;
using Broker.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using B = BCrypt.Net;

namespace Broker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IMapper mapper, UserManager<User> userManager)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public JsonResult GetSomething()
        {
            var categories = _db.Categories.ToList();
            var data = JsonConvert.SerializeObject(categories);

            return Json(data);
        }

        public IActionResult Index()
        {

            List<HomeViewModel> homeViewModels = new List<HomeViewModel>();

            var categories = this._db.Categories.ToList();

            foreach (var category in categories)
            {
                HomeViewModel model = new HomeViewModel();

                model.category = category;
                model.posts = this._db.Posts.Where(p => p.PostCategories.Any(x => x.CategoryId == category.CategoryId)).Take(10).ToList();

                if (model.posts.Count != 0)
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

        

        

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult AdsPayment()
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

    }
}
