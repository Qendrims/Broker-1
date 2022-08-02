using Broker.ApplicationDB;
using Broker.Models;
using Broker.Repository.IRepository;
using Broker.Services.Repository;
using Microsoft.Extensions.Logging;

namespace Broker.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext Dbcontext, ILogger logger) : base(Dbcontext, logger)
        {

        }
    }
}
