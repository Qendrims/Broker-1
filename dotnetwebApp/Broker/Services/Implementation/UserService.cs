using AutoMapper;
using Broker.Mailing;
using Broker.Models;
using Broker.Services.Interface;
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
        private IMapper _mapper;
        private IEmailSender _emailSender;

        public UserService(IHttpContextAccessor httpContextAccessor, SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper, IEmailSender emailSender)
        {
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

        public bool IsLoggedIn(LoginUserModel loginUser)
        {
            if (loginUser != null)
            {
                var result = _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, false);
                return true;
            }
            else
            {
                return false;
            }
        }

        public User RegisterUser(LoginUserModel loginUser)
        {
            User user;
            user = _mapper.Map<User>(loginUser);

            var result = _userManager.CreateAsync(user, loginUser.Password);
            //var result = _signInManager.PasswordSignInAsync(agent.Email, agent.PasswordHash, false, false);
            if (result.IsCompleted)
            {
                //await _signInManager.SignInAsync(user, isPersistent: false);

                return user;
            }
            return null;
        }
        public Task<string> GetUserToken(User user)
        {
            //Generate Email Confirmation token
            var token = _userManager.GenerateEmailConfirmationTokenAsync(user);
            _userManager.ConfirmEmailAsync(user, token.Result);
            return token;
        }

        public object RegisterUser(RegisterViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
