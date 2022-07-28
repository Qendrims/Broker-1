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
        private ILogger _logger; 
        public IUserRepository Users { get; private set; }
        public UnitOfWork(ApplicationDbContext applicationDbContext, ILogger logger)
        {
            this._applicationDbContext = applicationDbContext;
            this._logger = logger;

            Users = new UserRepository(_applicationDbContext, _logger);
        }

        

        public  void Dispose()
        {
            _applicationDbContext.Dispose();
        }
         
        public async Task Save()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
