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

        //[HttpGet]
        //public JsonResult GetSomething()
        //{


        //    List<PostViewModel> posts = new List<PostViewModel>();
        //    PostViewModel post = new PostViewModel("Home");
        //    PostViewModel post1 = new PostViewModel("Flat");
        //    PostViewModel post2 = new PostViewModel("Office");
        //    PostViewModel post3 = new PostViewModel("Home");
        //    PostViewModel post4 = new PostViewModel("Flat");
        //    PostViewModel post5 = new PostViewModel("Home");
        //    PostViewModel post6 = new PostViewModel("Flat");
        //    PostViewModel post7 = new PostViewModel("Flat");
        //    posts.Add(post);
        //    posts.Add(post1);
        //    posts.Add(post2);
        //    posts.Add(post3);
        //    posts.Add(post4);
        //    posts.Add(post5);
        //    posts.Add(post6);
        //    posts.Add(post7);


        //    //HomeViewModel HomeModel = new HomeViewModel();
        //    //HomeModel.posts = posts;
        //    //HomeModel.categories = new HashSet<string>(posts.Select(x => x.Category)).ToList();
        //    //var data = JsonConvert.SerializeObject(HomeModel.categories);

        //    return Json(data);
        //}

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
        public IActionResult Login(LoginUserModel loginUser)
        {

            var user = this._db.Users.Where(u => u.Email == loginUser.Email).FirstOrDefault();
            bool validUser =false;

            if (user != null)
            {
                validUser = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password);
            }
            else {
                ViewBag.Message = "Username or Password is incorrect";
                return View();
            }

            if (!validUser)
            {
                ViewBag.Message = "Username or Password is incorrect";
                return View();
            }
            else {
                return RedirectToAction("Index");
            }

        }

        public IActionResult RegisterAsAgent()
        {

            return View();

        }

        [HttpPost]
        public IActionResult RegisterAsAgent(Agent agent)
        {
            if (ModelState.IsValid)
            {
                agent.Password = Bc.HashPassword(agent.Password);
                _db.Agents.Add(agent);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else { 
                return View();
            }

        }


        public IActionResult RegisterAsSimpleUser()
        {

            return View();

        }

        [HttpPost]
        public IActionResult RegisterAsSimpleUser(SimpleUser simpleUser)
        {
            if (ModelState.IsValid)
            {
                simpleUser.Password = Bc.HashPassword(simpleUser.Password);
                _db.SimpleUsers.Add(simpleUser);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
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
        
    }
}
