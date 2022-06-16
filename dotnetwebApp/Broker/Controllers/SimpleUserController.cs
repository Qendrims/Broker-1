using Broker.ApplicationDB;
using Broker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Broker.Controllers
{
    public class SimpleUserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SimpleUserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult HomePage()
        {
            List<HomeViewModel> homeViewModels = new List<HomeViewModel>();

            var categories = this._db.Categories.ToList();

            foreach (var category in categories)
            {
                HomeViewModel model = new HomeViewModel();

                model.category = category;
                model.posts = this._db.Posts.Where(p => p.PostCategories.Any(x => x.CategoryId == category.CategoryId)).ToList();

                if (model.posts.Count != 0)
                {
                    homeViewModels.Add(model);
                }
            }
            return View(homeViewModels);
        }
    }
}
