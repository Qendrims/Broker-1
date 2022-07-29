using Broker.ApplicationDB;
using Broker.Repository;
using Broker.Repository.IRepository;
using Broker.Services.Repository.IRepository;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Broker.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _applicationDbContext;
        private ILogger logger;
        private UserRepository _userRepository;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
            Users = new UserRepository(_applicationDbContext, logger);
        }
        public IUserRepository Users{ get; private set; }
        public IPostRepository Post { get; private set; }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public async Task Save()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
