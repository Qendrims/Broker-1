using Broker.ApplicationDB;
using Broker.Models;
using Broker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Broker.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PostController(ApplicationDbContext applicationDb)
        {
            this._db = applicationDb;
        }

        //public IActionResult PostPage(int pg =1)
        //{
        //    FilteredPostViewModel posts = new FilteredPostViewModel();
        //    posts.FilteredPosts = _db.Posts.ToList();
        //    posts.FilteredCategories = _db.Categories.ToList();

        //    const int pageSize = 2;
        //    if (pg < 1)
        //        pg = 1;

        //    int postCount = posts.FilteredPosts.Count();
        //    var pager = new Pagination(postCount, pg, pageSize);

        //    int postSkip = (pg - 1) * pageSize;

        //    posts.FilteredPosts = posts.FilteredPosts.Skip(postSkip).Take(pager.PageSize).ToList();
        //    this.ViewBag.Pager = pager;
        //    return View(posts);
        //   // return View(posts);
        //}

        public IActionResult PostPage(string category, string city, int pg = 1)
        {

            FilteredPostViewModel posts = new FilteredPostViewModel();
            posts.FilteredCategories = _db.Categories.ToList();
            Category cat = new Category();
            if (category != null)
            {
                cat = _db.Categories.First(c => c.CategoryName == category);
            }
            var result = _db.Posts.Where(p => category == null || p.PostCategories.Any(pc => pc.CategoryId == cat.CategoryId))
                .Where(p => city == null || p.City.ToLower() == city.ToLower()).ToList();
            posts.FilteredPosts = result;
            posts.Category = category;
            posts.City = city;

            const int postPerPage = 2;
            if (pg < 1)
                pg = 1;

            int postCount = posts.FilteredPosts.Count();
            var pager = new Pagination(postCount, pg, postPerPage);

            int postSkip = (pg - 1) * postPerPage;

            posts.FilteredPosts = posts.FilteredPosts.Skip(postSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View("PostPage", posts);
        }

        public IActionResult MyPosts(int UseriId = 1, int pg = 1)
        {
            FilteredPostViewModel posts = new FilteredPostViewModel();

            posts.FilteredPosts = _db.Posts.Where(p => p.PostUserId == UseriId).ToList();

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

        public IActionResult ArchivedPosts(int id=1, int pg = 1)
        {
            FilteredPostViewModel posts = new FilteredPostViewModel();
            //var posts=this._db.Posts.Where(x => x.PostId== id && x.IsArchived==true).ToList();
            posts.FilteredPosts= _db.Posts.Where(x => x.PostId == id && x.IsArchived == true).ToList();


            const int postPerPage = 2;
            if (pg < 1)
                pg = 1;

            int postCount = posts.FilteredPosts.Count();
            var pager = new Pagination(postCount, pg, postPerPage);

            int postSkip = (pg - 1) * postPerPage;

            posts.FilteredPosts = posts.FilteredPosts.Skip(postSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(posts);

            return View();
        }
    }
}
