using Broker.Models;
using Broker.ViewModels;
using System.Threading.Tasks;

namespace Broker.Services.Interface
{
    public interface IUserService
    {
        public string GetUserId();

        bool IsLoggedIn(LoginUserModel loginUser);

        User RegisterUser(LoginUserModel loginUser);

        Task<string> GetUserToken(User user);
        object RegisterUser(RegisterViewModel model);
    }
}
