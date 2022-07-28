using Broker.Models;
using System.Threading.Tasks;

namespace Broker.Services.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
    }
}
