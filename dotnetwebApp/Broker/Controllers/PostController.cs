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
        public IActionResult PostPage()
        {
            FilteredPostViewModel posts = new FilteredPostViewModel();
            posts.FilteredPosts = _db.Posts.ToList();
            posts.FilteredCategories = _db.Categories.ToList();
            return View(posts);
        }

        public IActionResult GetFilteredPosts(string category, string city)
        {

            FilteredPostViewModel posts = new FilteredPostViewModel();
            posts.FilteredCategories = _db.Categories.ToList();
            Category cat = _db.Categories.First(c => c.CategoryName == category);
            var result = _db.Posts.Where(p => category == null || p.PostCategories.Any(pc => pc.CategoryId == cat.Id))
                .Where(p => city == null || p.City.ToLower() == city.ToLower()).ToList();
            posts.FilteredPosts = result;
            posts.Category = category;
            posts.City = city;
            return View("PostPage", posts);
        }
    }
}
