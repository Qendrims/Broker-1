using Broker.Models;
using Broker.ViewModels;
using System.Threading.Tasks;

namespace Broker.Services.Interface
{
    public interface IUserService
    {
        public string GetUserId();

        Task<bool> IsLoggedIn(LoginUserModel loginUser);

        Task<User> RegisterUser(LoginUserModel loginUser);

        Task<string> GetUserToken(User user);
    }
}
