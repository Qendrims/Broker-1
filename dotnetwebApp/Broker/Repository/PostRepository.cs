using Broker.Models;
using Broker.Repository.IRepository;
using Broker.Services.Repository;
using Broker.UOW;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Broker.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(UnitOfWork Dbcontext, ILogger logger) : base(Dbcontext, logger)
        {
        }
    }
}
