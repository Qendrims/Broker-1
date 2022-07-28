using Broker.Services.Repository.IRepository;
using System;
using System.Threading.Tasks;

namespace Broker.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        Task Save();
    }
}
