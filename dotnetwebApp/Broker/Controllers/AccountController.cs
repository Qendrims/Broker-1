using Broker.ApplicationDB;
using Broker.Models;
using Broker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _db;
        public AccountController(UserManager<User> userManager,
                                      SignInManager<User> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FullName = model.FullName,
                    UserName = model.EmailAddress,
                    Email = model.EmailAddress,
                    Birthday = model.Birthday,
                    PhoneNumber = model.PhoneNumber

                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Register Attempt");

            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult MyPost()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var posts = _db.Posts.Where(p => p.PostUserId == userId && p.IsArchived == false);


            return View(posts);
        }
        public IActionResult Index()
        {
            var archived = _db.Posts.Where(p => p.IsArchived == true).ToList();
            return View(archived);
        }

        public IActionResult ArchivePost(int id)
        {

            var posts = _db.Posts.Where(p => p.PostId == id).FirstOrDefault();
            posts.IsArchived = true;
            _db.Posts.Update(posts);
            _db.SaveChanges();

            return RedirectToAction("MyPost", "Account");

        }
        public IActionResult Unarchive(int id)
        {

            var posts = _db.Posts.Where(p => p.PostId == id).FirstOrDefault();
            posts.IsArchived = !posts.IsArchived;
            _db.Posts.Update(posts);
            _db.SaveChanges();

            return RedirectToAction("MyPost");

        }
        public IActionResult MyArchivedPosts()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var posts = _db.Posts.Where(p => p.PostUserId == userId && p.IsArchived == true);
            return View(posts);
        }
        public IActionResult DeletePost(int id)
        {
            var post = _db.Posts.Where(p => p.PostId == id).FirstOrDefault();
            _db.Posts.Remove(post);
            _db.SaveChanges();

            return RedirectToAction("MyPost");

        }
        public IActionResult SponsorePost(int id)
        {
            var post = _db.Posts.Where(p => p.PostId == id).FirstOrDefault();

            post.IsSponsored = true;
            _db.Posts.Update(post);
            _db.SaveChanges();

            return RedirectToAction("MyPost");

        }
        public IActionResult ProfileDetails()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _db.users.Find(userId);
            return View(user);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var user = _db.users.Where(p=>p.Id==id).FirstOrDefault();
            
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User model)
        {
            var userEdited = _db.users.Find(model.Id);
            if (!ModelState.IsValid) {
                
                return View(model);
            }
            if (String.IsNullOrEmpty(model.PhoneNumber))
            {
                return View(model);
            }
           
                userEdited.FullName = model.FullName;
                userEdited.PhoneNumber = model.PhoneNumber;
                userEdited.Birthday = model.Birthday;

            _db.users.Update(userEdited);
            _db.SaveChanges();
            

            return RedirectToAction("ProfileDetails");
        }
    }
}