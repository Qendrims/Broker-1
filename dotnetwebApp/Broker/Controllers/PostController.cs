using Broker.ApplicationDB;
using Broker.Models;
using Broker.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BrokerApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostController(ApplicationDbContext _context, IWebHostEnvironment _webHostEnvironment)
        {
            this._db = _context;
            this._webHostEnvironment = _webHostEnvironment;
        }

        public IActionResult Archive(int? id)
        {
            var post = _db.Posts.Where(p => p.PostId == id).FirstOrDefault();
            post.IsArchived = true;
            _db.Posts.Update(post);
            _db.SaveChanges();

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
        public IActionResult MyPosts(int UseriId = 1, int pg = 1)
        {
            FilteredPostViewModel posts = new FilteredPostViewModel();

            posts.FilteredPosts = _db.Posts.Where(p => p.PostUserId.Equals(UseriId)).ToList();

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
        public IActionResult ArchivedPosts(int id = 1, int pg = 1)
        {
            FilteredPostViewModel posts = new FilteredPostViewModel();
            posts.FilteredPosts = _db.Posts.Where(x => x.PostId == id && x.IsArchived == true).ToList();


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

        public IActionResult PostPage(string category, string city, int pg = 1)
        {

            FilteredPostViewModel posts = new FilteredPostViewModel();
            posts.FilteredCategories = _db.Categories.ToList();
            posts.Cities = _db.Posts.Where(p => !string.IsNullOrEmpty(p.City)).Select(m => m.City).Distinct().ToList();

            Category cat = new Category();
            if (category != null)
            {
                cat = _db.Categories.First(c => c.CategoryName == category);
            }
            var result = _db.Posts.Where(p => category == null || p.PostCategories.Any(pc => pc.CategoryId == cat.CategoryId))
                .Where(p => city == null || p.City.ToLower() == city.ToLower()).Where(p => p.IsArchived == false).ToList();
            posts.FilteredPosts = result;
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
        public IActionResult Detail(int? id)
        {
            var post1 = this._db.Posts.Where(p => p.PostId == id).Include(x => x.User).Include(x => x.Images).FirstOrDefault();

            //Image img = this._Dbcontext.Images.Where(i => i.PostId == id).FirstOrDefault();

            PostDetailViewModel postViewModel = new PostDetailViewModel();

            postViewModel.Title = post1.Title;
            postViewModel.Description = post1.Description;
            postViewModel.Price = post1.Price;
            postViewModel.OwnerId =Convert.ToInt32(post1.PostUserId);
            
            postViewModel.Image = post1.Images.FirstOrDefault();
            postViewModel.PostId = post1.PostId;

            return View(postViewModel);
        }
        [HttpGet]
        public IActionResult PostPageCreate()
        {
            PostViewModel createPostView = new PostViewModel();


            createPostView.categories = this._db.Categories.ToList();
            
            return View(createPostView);
        }
        [HttpPost]
        public JsonResult PostPageCreate(PostViewModel postView)
        {
            string folder = Environment.CurrentDirectory;



            Post post = new Post();

            post.Title = postView.Title;
            post.Description = postView.Description;
            post.PostUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            post.City = postView.City;
            post.State = postView.State;
            post.Street = postView.Street;
            post.Latitude = postView.Latitude;
            post.Longitude = postView.Longitude;
            post.ZipCode = postView.ZipCode;
            
            if (ModelState.IsValid)
            {
                this._db.Posts.Add(post);


                foreach (var imageFile in postView.Image)
                {
                    string fileName = postView.Title + "-" + DateTime.Now.ToString("MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + ".jpg";
                    string fullFileName = fileName.Replace(":", "-").Replace(" ", "");
                    string filePath = $"{folder}\\wwwroot\\UploadFiles\\{fullFileName}";

                    //string fileName = Path.GetFileName(postView.Image[0].FileName); 
                    //string webRootPath = _webHostEnvironment.WebRootPath+ "\\Uploads\\"+ fileName;

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        imageFile.CopyTo(stream);
                    }

                    PostImage image = new PostImage();
                    image.ImageName = fullFileName;
                    image.Post = post;
                    image.Type = "jpg";
                    this._db.PostImages.Add(image);
                }

                if (postView.CategoryId != null)
                {
                    foreach (var catId in postView.CategoryId)
                    {
                        PostCategory postCategory = new PostCategory();
                        postCategory.CategoryId = catId;
                        postCategory.Post = post;
                        this._db.PostCategories.Add(postCategory);
                    }
                }

             


                _db.SaveChanges();

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
        [HttpPost]
        public IActionResult Edit(int? id,Post? model)
        {
            
                var post = _db.Posts.Find(id);
            if (ModelState.IsValid) {
                post.Title = model.Title;
                post.Description = model.Description;
                post.City = model.City;
                post.Country = model.Country;
                post.Price = model.Price;
                _db.Update(post);
                _db.SaveChanges();
                    }

            return View("ViewEdit",post);
        }

        //public IActionResult Edit(int? id)
        //{
        //    if (id == 0)
        //    {
        //        return View(new Post());
        //    }
        //    else
        //    {
        //        var post = this._db.Posts.Where(x => x.PostId == id).Include(x => x.Images).FirstOrDefault();
        //        PostDetailViewModel postViewModel = new PostDetailViewModel();
        //        postViewModel.Title = post.Title;
        //        postViewModel.Description = post.Description;
        //        postViewModel.Price = post.Price;
        //        postViewModel.Image = post.Images.FirstOrDefault();
        //        return View(postViewModel);

        //    }
        //}
        public IActionResult EditView(int? id)
        {
            if (id == 0)
            {
                return View(new Post());
            }
            else
            {
                var post = this._db.Posts.Where(x => x.PostId == id).Include(x => x.Images).FirstOrDefault();
                PostDetailViewModel postViewModel = new PostDetailViewModel();
                postViewModel.Title = post.Title;
                postViewModel.Description = post.Description;
                postViewModel.Price = post.Price;
                postViewModel.Image = post.Images.FirstOrDefault();
                return View(postViewModel);

            }
        }


        [HttpPost]
        public IActionResult Edit(int id, PostDetailViewModel ViewModel)
        {
            var post = this._db.Posts.Where(x => x.PostId == id).Include(e => e.Images).FirstOrDefault();



            post.Title = ViewModel.Title;
            post.Description = ViewModel.Description;
            ViewModel.Image = post.Images.FirstOrDefault();
            post.Price = ViewModel.Price;

            this._db.Update(post);
            this._db.SaveChanges();
            return View("Detail", ViewModel);

        }
        public IActionResult Delete()
        {
            return View();
        }
        //Cdo sen qe vjen prej URl By default esjte get
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var postToDelete = this._db.Posts.Where(x => x.PostId == id).FirstOrDefault();
            this._db.Posts.Remove(postToDelete);
            this._db.SaveChanges();

            return RedirectToAction("PostPageCreate");
        }

     
    }
}
