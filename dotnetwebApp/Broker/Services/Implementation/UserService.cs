using Broker.Models;
using Broker.Services.Interface;
using Broker.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Broker.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<User> _signInManager;

        public UserService(IHttpContextAccessor httpContextAccessor, SignInManager<User> signInManager)
        {
            _httpContextAccessor = httpContextAccessor;
            this._signInManager = signInManager;
        }
        public string GetUserId()
        {
            return _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
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
    }
}
