using Broker.ApplicationDB;
using Broker.Models;
using Broker.Repository.IRepository;
using Broker.Services.Repository;
using Broker.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Broker.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext Dbcontext, ILogger logger) : base(Dbcontext, logger)
        {

        }

        public List<Post> FiltredPost(int catId,string category, string city, double? minPrice, double? maxPrice, int? rooms, int? bathrooms, int? size)
        {
            return this._Dbcontext.Posts.Where(p => category == null || p.PostCategories.Any(pc => pc.CategoryId == catId))
                .Where(p => city == null || p.City.ToLower() == city.ToLower())
                .Where(p => minPrice == null || p.Price >= minPrice)
                .Where(p => maxPrice == null || p.Price <= maxPrice)
                .Where(p => rooms == null || p.Rooms == rooms)
                .Where(p => bathrooms == null || p.BathRooms == bathrooms)
                .Where(p => size == null || p.Size == size)
                .Where(p => p.IsArchived == false)
                .Include(p => p.Images).ToList();
        }

        public List<Post> Get10PostByCategory(Category category)
        {
            return this._Dbcontext.Posts.Where(p => p.PostCategories.Any(x => x.CategoryId == category.CategoryId)).Take(10).ToList();
        }
        public List<string> GetAllCities()
        {
            return this._Dbcontext.Posts.Where(p => !string.IsNullOrEmpty(p.City)).Select(m => m.City).Distinct().ToList();
        }

        public ICollection<PostImage> GetImagesToDelete(PostDetailViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Post GetPostToEdit(int id)
        {
            return this._Dbcontext.Posts.Where(x => x.PostId == id).Include(x => x.Images).FirstOrDefault();
        }

        public Post GetPostToEdit(PostDetailViewModel viewModel)
        {
            return null;
        }

        public Post GetPostWithImages(int id)
        {
            return this._Dbcontext.Posts.Where(p => p.PostId == id).Include(y => y.PostCategories).ThenInclude(x => x.Category).Include(x => x.User).Include(x => x.Images).FirstOrDefault();
        }
        public Post GetPostWithImages(PostDetailViewModel ViewModel)
        {
            return this._Dbcontext.Posts.Where(x => x.PostId == ViewModel.PostId).Include(e => e.Images).FirstOrDefault();
        }
        public override void Remove(Post entity)
        {
            var post=this._Dbcontext.Posts.Find(entity.PostId);
            post.IsDeleted = true;
            post.IsActive = false;
            this._Dbcontext.Posts.Update(post);
        }
    }
}
