
using AutoMapper;
using Broker.ApplicationDB;
using Broker.FileHelper;
using Broker.Models;
using Broker.Services;
using Broker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Broker.Services.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Broker.Services.Interface;


namespace BrokerApp.Controllers
{
    public class PostController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _Dbcontext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IMapper _mapper;
        private readonly IPostService _postService; 
        private readonly IUserService _userService;

        public PostController(ApplicationDbContext _context, IUserService userService, IWebHostEnvironment _webHostEnvironment, IMapper mapper, UserManager<User> userManager, IPostService postService)
        {
            this._Dbcontext = _context;
            this._webHostEnvironment = _webHostEnvironment;
            this._mapper = mapper;
            this._userManager = userManager;
            this._postService = postService;
            this._userService = userService;
        }

        public IActionResult Archive(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var post = _Dbcontext.Posts.Where(p => p.PostId == id).FirstOrDefault();
            post.IsArchived = true;
            _Dbcontext.Posts.Update(post);
            _Dbcontext.SaveChanges();

            return RedirectToAction("PostPage");
        }

        //    int postCount = posts.FilteredPosts.Count();
        //    var pager = new Pagination(postCount, pg, pageSize);

        //    int postSkip = (pg - 1) * pageSize;

        //    posts.FilteredPosts = posts.FilteredPosts.Skip(postSkip).Take(pager.PageSize).ToList();
        //    this.ViewBag.Pager = pager;
        //    return View(posts);
        //   // return View(posts);
        //}

        [Authorize]
        public IActionResult MyPosts(string id, int pg = 1)
        {
            this._userService.TrackUser();
            FilteredPostViewModel posts = new FilteredPostViewModel();

            posts.FilteredPosts = _Dbcontext.Posts.Where(p => p.PostUserId == id).Include(x => x.Images).ToList();

            const int postPerPage = 6;
            if (pg < 1)
                pg = 1;

            int postCount = posts.FilteredPosts.Count();
            var pager = new Pagination(postCount, pg, postPerPage);

            int postSkip = (pg - 1) * postPerPage;

            posts.FilteredPosts = posts.FilteredPosts.Skip(postSkip).Take(pager.PageSize).ToList();
           
            this.ViewBag.Pager = pager;

            return View(posts);
        }
        public IActionResult ArchivedPosts(int id = 1, int pg = 1)
        {
            FilteredPostViewModel posts = new FilteredPostViewModel();
            posts.FilteredPosts = _Dbcontext.Posts.Where(x => x.PostId == id && x.IsArchived == true).ToList();


            const int postPerPage = 2;
            if (pg < 1)
                pg = 1;

            int postCount = posts.FilteredPosts.Count();
            var pager = new Pagination(postCount, pg, postPerPage);

            int postSkip = (pg - 1) * postPerPage;

            posts.FilteredPosts = posts.FilteredPosts.Skip(postSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(posts);
        }

        [Authorize]
        public IActionResult PostPage(string category, string city,double? minPrice,double? maxPrice,int? rooms,int? bathrooms,int? size, int pg = 1)
        {

            this._userService.TrackUser();
            FilteredPostViewModel posts = new FilteredPostViewModel();
            posts.FilteredCategories = _Dbcontext.Categories.ToList();
            posts.Cities = _Dbcontext.Posts.Where(p => !string.IsNullOrEmpty(p.City)).Select(m => m.City).Distinct().ToList();

            if (minPrice > maxPrice)
            {
                var newMin = minPrice;
                minPrice = maxPrice;
                maxPrice = newMin;
            }
            Category cat = new Category();
            if (category != null)
            {
                cat = _Dbcontext.Categories.First(c => c.CategoryName == category);
            }
            var result = _Dbcontext.Posts.Where(p => category == null || p.PostCategories.Any(pc => pc.CategoryId == cat.CategoryId))
                .Where(p => city == null || p.City.ToLower() == city.ToLower())
                .Where(p => minPrice == null || p.Price >= minPrice)
                .Where(p => maxPrice == null || p.Price <= maxPrice)
                .Where(p => rooms == null || p.Rooms == rooms)
                .Where(p => bathrooms == null || p.BathRooms == bathrooms)
                .Where(p => size == null || p.Size == size)
                .Where(p => p.IsArchived == false)
                .Include(p => p.Images).ToList();

            posts.FilteredPosts = result;
            if(result.Count > 0)
            posts.Image = result.FirstOrDefault().Images;
            posts.Category = category;
            posts.City = city;
            
            const int postPerPage = 20;
            if (pg < 1) 
                pg = 1;

            int postCount = posts.FilteredPosts.Count();
            var pager = new Pagination(postCount, pg, postPerPage);

            int postSkip = (pg - 1) * postPerPage;

            posts.FilteredPosts = posts.FilteredPosts.Skip(postSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;


            return View("PostPage", posts);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            this._userService.TrackUser();
            var post1 = this._Dbcontext.Posts.Where(p => p.PostId == id).Include(y => y.PostCategories).ThenInclude(x => x.Category).Include(x => x.User).Include(x => x.Images).FirstOrDefault();

            //var postCategories = this._Dbcontext.PostCategories.Where(p => p.PostId == id).Include(y => y.Category).Include(y => y.Post).ToList();
            //var post1 = postCategories.
            try
            {
                var saveMapper = _mapper.Map<PostDetailViewModel>(post1);
                return View(saveMapper);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult PostPageCreate()
        {
            this._userService.TrackUser();
            PostViewModel createPostView = _postService.GetCreatePostModel();
            return View(createPostView);
        }


        [HttpPost]
        public JsonResult PostPageCreate(PostViewModel postView)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    _postService.CreatePost(postView, HttpContext);

                    return Json(new { status = 200, message = "Post created successfully" });
                }
                else
                {

                    Dictionary<string, string> data = new Dictionary<string, string>();
                    if (string.IsNullOrEmpty(postView.Title))
                        data.Add("TitleError", "Title cant be empty");

                    if (string.IsNullOrEmpty(postView.Description))
                        data.Add("DescriptionError", "Description cant be empty");


                    return Json(new { status = 400, message = "Something went wrong", data });
                }

            }
            catch (Exception ex)
            {

                return Json(new { status = 400, message = ex.Message });
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {  
              var post = this._Dbcontext.Posts.Where(x => x.PostId == id).Include(x => x.Images).Include(x => x.PostCategories).Include(x => x.User).FirstOrDefault();
                
               
              var postViewModel = _mapper.Map<PostDetailViewModel>(post);
              postViewModel.categories = _Dbcontext.Categories.ToList();
              return View(postViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PostDetailViewModel ViewModel,int id)
        {

            var post = this._Dbcontext.Posts.Where(x => x.PostId == id).Include(e => e.Images).FirstOrDefault();
            var ImageToDelete = post.Images.Where(x => x.PostId == ViewModel.PostId).FirstOrDefault();

            try
            {

                post.Title = ViewModel.Title;
                post.Description = ViewModel.Description;
                post.NewPrice = ViewModel.NewPrice;
                if (ViewModel.ImageUploaded != null)
                    foreach (var image in ViewModel.ImageUploaded)
                    {
                        string fileName = MethodHelper.FileToBeSaved(ViewModel.Title, image).Result;
                        PostImage newimage = new PostImage();
                        newimage.ImageName = fileName;
                        newimage.Post = post;
                        newimage.Type = "jpg";
                        this._Dbcontext.PostImages.Add(newimage);
                        ViewModel.Image.Add(newimage);

                    }
                else
                {
                    ViewModel.Image = post.Images.ToList();
                }


                this._Dbcontext.Update(post);
                this._Dbcontext.SaveChanges();
                return Redirect("https://localhost:44359/Post/MyPosts/"+_userManager.GetUserId(User));
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }
        public IActionResult Delete()
        {
            return View();
        }
        //Cdo sen qe vjen prej URl By default esjte get
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {

                var postToDelete = this._Dbcontext.Posts.Find(id);
                var imageToDelete = this._Dbcontext.PostImages.Where(x => x.PostId == id).FirstOrDefault();
                this._Dbcontext.PostImages.Remove((PostImage)imageToDelete);
                this._Dbcontext.Posts.Remove(postToDelete);
                this._Dbcontext.SaveChanges();

                return RedirectToAction("PostPageCreate");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public IActionResult Ads(int? id)
        {
            var post = this._Dbcontext.Posts.Where(p => p.PostId == id).FirstOrDefault();
            return View(post);
        }

        [HttpPost]
        public IActionResult Ads(AdsPaymentViewModel viewModel)
        {
            AdsPayments ads = new AdsPayments();
            var saveMapper = _mapper.Map<AdsPayments>(viewModel);
            this._Dbcontext.AdsPaymentcs.Add(saveMapper);
            this._Dbcontext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
