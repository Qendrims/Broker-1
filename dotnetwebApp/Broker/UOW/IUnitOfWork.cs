using Broker.Services.Repository.IRepository;
using System.Threading.Tasks;

namespace Broker.UOW
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        void Save();
    }
}
