using Broker.ApplicationDB;
using Broker.Models;
using Broker.Services.Repository;
using Broker.Services.Repository.IRepository;
using Broker.UOW;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IUnitOfWork _db;
        private readonly ILogger _logger;
        public UserRepository(ApplicationDbContext Dbcontext, ILogger logger) : base(Dbcontext, logger)
        {

        }
    }
}
