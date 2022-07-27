using Broker.Services.Repository.IRepository;
using System;
using System.Threading.Tasks;

namespace Broker.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        Task Save();
    }
}
