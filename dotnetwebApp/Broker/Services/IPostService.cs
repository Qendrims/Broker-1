using Broker.Models;
using Microsoft.AspNetCore.Http;

namespace Broker.Services
{
    public interface IPostService
    {
        public PostViewModel GetCreatePostModel();
        public void CreatePost(PostViewModel postView, HttpContext context);
    }
}
