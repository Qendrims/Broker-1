using AutoMapper;
using Broker.Mailing;
using Broker.Models;
using Broker.Services.Interface;
using Broker.UOW;
using Broker.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Broker.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork unitOfWork;
        private IMapper _mapper;
        private IEmailSender _emailSender;

        public UserService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper, IEmailSender emailSender)
        {
            this.unitOfWork = unitOfWork;
            this._httpContextAccessor = httpContextAccessor;
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._mapper = mapper;
            this._emailSender = emailSender;
        }
        public string GetUserId()
        {
            return _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public Task<string> GetUserToken(LoginUserModel loginUser)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> IsLoggedIn(LoginUserModel loginUser)
        {
            if (loginUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, false);

                if (result.Succeeded) return true;

            }

            return false;
        }

        public async Task<User> RegisterUser(LoginUserModel loginUser)
        {
            User user;
            user = _mapper.Map<User>(loginUser);

            var result = await _userManager.CreateAsync(user, loginUser.Password);
            //var result = _signInManager.PasswordSignInAsync(agent.Email, agent.PasswordHash, false, false);
            if (result.Succeeded)
            {
                //await _signInManager.SignInAsync(user, isPersistent: false);

                return user;
            }
            return null;
        }
        public async Task<bool> GetUserToken(User user)
        {
            try
            {
                //Generate Email Confirmation token
                var token = _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.ConfirmEmailAsync(user, token.Result);
                var confrimationLink = "https://localhost:44359/Index/Home?token=" + token;
                await _emailSender.SendEmailAsync(user.Email, "Confirm email", "Confirm email by pressing this link: <a href=\"" + confrimationLink + "\">link</a>");
                return true;
            }
            catch {
                return false;
            }
        }

        //take all users qe kane nje postim
        private void test() 
        {
            var users = this.unitOfWork.Users.GetAllUersWithOnePost();
            
        }


    }
}
