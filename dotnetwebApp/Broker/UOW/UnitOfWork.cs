using Broker.ApplicationDB;
using Broker.Repository.IRepository;
using Broker.Services.Repository.IRepository;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Broker.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; set; }
        public IPostRepository Posts { get; set; }
        public UnitOfWork(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }


        public void Save()
        {
            this._context.SaveChanges();
        }
    }
}
