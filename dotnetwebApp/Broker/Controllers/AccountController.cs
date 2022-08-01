using AutoMapper;
using Broker.ApplicationDB;
using Broker.Models;
using Broker.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Broker.Data;

namespace Broker.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager,ApplicationDbContext db, IMapper mapper) {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
            this._mapper = mapper;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserModel loginUser)
        {
            if (ModelState.IsValid)
            {
                var user =await _userManager.FindByEmailAsync(loginUser.Email);
                bool validUser;

                if (user != null)
                {
                    validUser = await _userManager.CheckPasswordAsync(user,loginUser.Password);
                    if (validUser) {
                        var result = await _signInManager.PasswordSignInAsync(user,loginUser.Password,false,false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("PostPage","Post");
                        }
                    }
                    ViewBag.Message = "Username or Password is incorrect";
                    return View();

                }
                else
                {
                    ViewBag.Message = "Username or Password is incorrect";
                    return View();
                }
                
            }
            else {
                return View();
            }
            

        }

        public IActionResult RegisterUser()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel userRegistered)
        {

            if (!ModelState.IsValid)
            {
                return View(userRegistered);
            }

            var user = await _userManager.FindByEmailAsync(userRegistered.Email);
            if (user != null) {
                ViewBag.Message = "This email address is already in use!";
                return View(userRegistered);
            }

            var newUser = _mapper.Map<User>(userRegistered);
            newUser.UserName = newUser.Email;

            var result = await _userManager.CreateAsync(newUser, userRegistered.Password);
            
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (!string.IsNullOrEmpty(token)) {
                    
                }
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            
            return View("RegisterCompleted");

        }


        

        [HttpGet]
        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
