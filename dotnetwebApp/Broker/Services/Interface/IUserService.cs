using Broker.ViewModels;
using System.Threading.Tasks;

namespace Broker.Services.Interface
{
    public interface IUserService
    {
        public string GetUserId();

        bool IsLoggedIn(LoginUserModel loginUser);
    }
}
