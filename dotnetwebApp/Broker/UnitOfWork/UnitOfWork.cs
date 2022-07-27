using Broker.ApplicationDB;
using Broker.Services.Repository.IRepository;
using System.Threading.Tasks;

namespace Broker.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IUserRepository _userRepository;
        public IUserRepository Users
        {
            get
            {
                if (this._userRepository == null)
                {
                    return _userRepository;
                }
                else throw new System.Exception("This user not existed!");
            }
        }

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
