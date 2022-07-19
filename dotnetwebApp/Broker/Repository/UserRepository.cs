using Broker.ApplicationDB;
using Broker.Models;
using Broker.Services.Repository;
using Broker.Services.Repository.IRepository;
using Microsoft.Extensions.Logging;

namespace Broker.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext Dbcontext, ILogger logger) : base(Dbcontext, logger)
        {

        }


    }
}
