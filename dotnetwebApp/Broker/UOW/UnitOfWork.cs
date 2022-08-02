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
        private PostRepository _postRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
            Users = new UserRepository(_applicationDbContext, logger);
            Posts = new PostRepository(applicationDbContext, logger);
            Categories = new CategoryRepository(applicationDbContext, logger);
        }
        public IUserRepository Users{ get; private set; }
        public IPostRepository Posts { get; private set; }
        public ICategoryRepository Categories { get; private set; }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }

        public async Task Save()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
