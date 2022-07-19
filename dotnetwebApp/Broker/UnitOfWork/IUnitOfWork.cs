using Broker.Services.Repository.IRepository;
using System.Threading.Tasks;

namespace Broker.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        Task Save();
    }
}
