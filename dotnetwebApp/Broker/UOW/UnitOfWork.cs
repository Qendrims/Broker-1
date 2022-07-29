using Broker.ApplicationDB;
using Broker.Repository;
using Broker.Services.Repository.IRepository;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Broker.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _applicationDbContext;
        private ILogger logger;
        private IUserRepository _userRepository;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
            Users = new UserRepository(_applicationDbContext, logger);
        }
        public IUserRepository Users{ get; private set; }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
