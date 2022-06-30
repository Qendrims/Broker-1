using AutoMapper;
using Broker.ApplicationDB;
using Broker.Mailing;
using Broker.Models;
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

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper, IEmailSender emailSender)
        {
            this._logger = logger;
            this._db = db;
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._mapper = mapper;
            _emailSender = emailSender;
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
        public async Task<IActionResult> Login(LoginUserModel loginUser)
        {
            if (ModelState.IsValid)
            {

                var result = await this._signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(loginUser);


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
        public async Task<IActionResult> RegisterAsAgent(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                User user;
                if (model.Type == "agent")
                {
                    user = _mapper.Map<Agent>(model);
                }
                else if (model.Type == "SimpleUser")
                {
                    user = _mapper.Map<SimpleUser>(model);
                }
                else 
                { 
                   user = _mapper.Map<User>(model); 
                }

                var result = await _userManager.CreateAsync(user, model.Password);
                //var result = _signInManager.PasswordSignInAsync(agent.Email, agent.PasswordHash, false, false);
                if (result.Succeeded)
                {
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    
                    //Generate Email Confirmation token
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    await _userManager.ConfirmEmailAsync(user, token);
                    //Generate Email Confrimation Link
                    var confrimationLink = Url.Action("Index", "Home",
                        new { token = token }, Request.Scheme);
                    await _emailSender.SendEmailAsync(model.Email, "Confirm email", "Confirm email by pressing this link: <a href=\"" + confrimationLink + "\">link</a>");
                    //Log confirmation lint to a file
                    _logger.Log(LogLevel.Warning, confrimationLink);
                    //await _userManager.AddToRoleAsync(user, "Visitor");
                }

            }

            return View(model);

        }


        public IActionResult RegisterAsSimpleUser()
        {

            return View();

        }

        [HttpPost]
        public IActionResult RegisterAsSimpleUser(SimpleUser simpleUser)
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
