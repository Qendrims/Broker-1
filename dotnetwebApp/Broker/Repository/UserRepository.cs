using Broker.ApplicationDB;
using Broker.Models;
using Broker.Services.Repository;
using Broker.Services.Repository.IRepository;
using Broker.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

        public List<User> GetAllUersWithOnePost()
        {
            return base._Dbcontext.Users.Include(x => x.Posts).Where(x => x.IsDeleted == false).ToList();
        }

        public override void Add(User entity)
        {

            base.Add(entity);
        }
    }
}
