using Broker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Broker.Services.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        List<User> GetAllUersWithOnePost();
    }
}
