using AutoMapper;
using Broker.ApplicationDB;
using Broker.Models;
using Broker.ViewModels;
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
        private IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db,IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            List<HomeViewModel> homeViewModels = new List<HomeViewModel>();

            var categories = this._db.Categories.ToList();

            foreach (var category in categories)
            {
                HomeViewModel model = new HomeViewModel();

                model.category = category;
                model.posts = this._db.Posts.Where(p => p.PostCategories.Any(x => x.CategoryId == category.CategoryId)).ToList();

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
        public IActionResult RegisterUser(RegisterUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (user.Type == "agent")
                {
                    Agent a = new Agent();
                    a = _mapper.Map<Agent>(user);
                    a.AgentId = user.AgentId;
                    _db.Agents.Add(a);
                    _db.SaveChanges();
                }
                else {
                    SimpleUser su = new SimpleUser();
                    su = _mapper.Map<SimpleUser>(user);
                    _db.SimpleUsers.Add(su);
                    _db.SaveChanges();
                }
                

                return RedirectToAction("Index");
            }
            else { 
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
