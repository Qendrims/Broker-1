using AutoMapper;
using Broker.ApplicationDB;
using Broker.Mailing;
using Broker.Models;
using Broker.Services.Interface;
using Broker.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private IMapper _mapper;
        private IEmailSender _emailSender;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper, IUserService userService, IEmailSender emailSender)
        {
            this._logger = logger;
            this._db = db;
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._mapper = mapper;
            _emailSender = emailSender;
            this._userService = userService;
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
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserModel loginUser, string returnUrl)
        {

            bool result = _userService.IsLoggedIn(loginUser).Result;
            if (result)
            {
                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("Login", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RegisterAsAgent()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsAgent(LoginUserModel model)
        {
            var user = _userService.RegisterUser(model);
            if (user != null)
            {

                var token = _userService.GetUserToken(user.Result);

                //Generate Email Confrimation Link
                var confrimationLink = Url.Action("Index", "Home",
                    new { token = token }, Request.Scheme);
                await _emailSender.SendEmailAsync(model.Email, "Confirm email", "Confirm email by pressing this link: <a href=\"" + confrimationLink + "\">link</a>");
                //Log confirmation lint to a file
                _logger.Log(LogLevel.Warning, confrimationLink);
                //await _userManager.AddToRoleAsync(user, "Visitor");
                return RedirectToAction("Index", "Home");

            }
            return View(model);

        }


        public IActionResult RegisterAsSimpleUser()
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

        public IActionResult Agents()
        {
            return View();
        }
    }
}