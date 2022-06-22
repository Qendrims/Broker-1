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
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, SignInManager<User> signInManager, UserManager<User> userManager)

        {
            this._logger = logger;
            this._db = db;
            this._signInManager = signInManager;
            this._userManager = userManager;

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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserModel loginUser)
        {
            await this._signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false,false);

            var user = this._db.Users.Where(u => u.Email == loginUser.Email).FirstOrDefault();
            bool validUser =false;

            if (user != null)
            {
                //validUser = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.PasswordHash);
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
            agent.UserName = agent.Email;
            _userManager.CreateAsync(agent, agent.Password);
            var result = _signInManager.PasswordSignInAsync(agent.Email, agent.PasswordHash, false, false);
            if (ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                return View("Error", "Post");
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
                simpleUser.Password = B.BCrypt.HashPassword(simpleUser.Password);
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
