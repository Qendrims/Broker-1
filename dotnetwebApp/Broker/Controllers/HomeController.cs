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
                validUser = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.PasswordHash);
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

        public IActionResult RegisterUser()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsAgent(RegisterAgentViewModel userRegistered)
        {

            User user;

            if (!ModelState.IsValid)
            {
                return View(userRegistered);
            }

            if(userRegistered.Type == "SimpleUser")
            {
               userRegistered.AgentId = null;
             user = _mapper.Map<SimpleUser>(userRegistered);
            } else if(userRegistered.Type == "Agent")
            {
                user = _mapper.Map<Agent>(userRegistered);
            } else
            {
                user = _mapper.Map<User>(userRegistered);
            }

            var result = await _userManager.CreateAsync(user, userRegistered.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(userRegistered);
            }
           // await _userManager.AddToRoleAsync(user, "Agent");
            return RedirectToAction(nameof(HomeController.Index), "Home");

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
                //simpleUser.Password = B.BCrypt.HashPassword(simpleUser.Password);
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

        public IActionResult Agents()
        {
            return View();
        }
    }
}
