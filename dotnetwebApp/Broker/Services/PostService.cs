using AutoMapper;
using Broker.ApplicationDB;
using Broker.FileHelper;
using Broker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Broker.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _Dbcontext;
        private IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public PostService(ApplicationDbContext Dbcontext, IMapper mapper, UserManager<User> userManager)
        {
            this._Dbcontext = Dbcontext;
            this._mapper = mapper;
            this._userManager = userManager;
        }
        public PostViewModel GetCreatePostModel()
        {
            PostViewModel createPostView = new PostViewModel();

            createPostView.categories = this._Dbcontext.Categories.ToList();
            return createPostView;
        }

        public void CreatePost(PostViewModel postView, HttpContext context)
        {
            postView.PostUserId = _userManager.GetUserId(context.User);
            var saveMapper = _mapper.Map<Post>(postView);
            this._Dbcontext.Posts.Add(saveMapper);

            CreatePostImage(postView, saveMapper);
            CreatePostCategory(postView, saveMapper);
            this._Dbcontext.SaveChanges();
        }

        private void CreatePostImage(PostViewModel postView, Post postMapper)
        {
            foreach (var imageFile in postView.Image)
            {
                string fullFileName = MethodHelper.FileToBeSaved(postView.Title, imageFile).Result;

                PostImage image = new PostImage();
                image.ImageName = fullFileName;
                image.Post = postMapper;
                image.Type = "jpg";
                this._Dbcontext.PostImages.Add(image);
            }
        }

        private void CreatePostCategory(PostViewModel postView, Post postMapper)
        {
            if (postView.CategoryId != null)
            {
                foreach (var catId in postView.CategoryId)
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.CategoryId = catId;
                    postCategory.Post = postMapper;
                    this._Dbcontext.PostCategories.Add(postCategory);
                }
            }
        }      
    }
}