using Broker.Models;
using Broker.Services.Repository.IRepository;
using Broker.ViewModels;
using System.Collections.Generic;

namespace Broker.Repository.IRepository
{
    public interface IPostRepository : IRepository<Post>
    {
        List<Post> Get10PostByCategory(Category category);
        List<string> GetAllCities();
        List<Post> FiltredPost(int catid,string category, string city, double? minPrice, double? maxPrice, int? rooms, int? bathrooms, int? size);
        Post GetPostWithImages(int id);
        Post GetPostToEdit(int id);
        Post GetPostToEdit(PostDetailViewModel viewModel);
        ICollection<PostImage> GetImagesToDelete(PostDetailViewModel viewModel);
    }
}
