using Broker.Repository.IRepository;
using Broker.Services.Repository.IRepository;
using System;
using System.Threading.Tasks;

namespace Broker.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IPostRepository Posts { get; } 
        ICategoryRepository Categories { get; } 

        Task Save();
    }
}
