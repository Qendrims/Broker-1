using AutoMapper;
using Broker.ApplicationDB;
using Broker.Models;
using Broker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Broker.Controllers
{
    public class SimpleUserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public SimpleUserController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            this._mapper = mapper;
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


        public IActionResult GetUserById(int id)
        {
            var User = _db.Users.Find(id);
            return View(User);
        }


        public IActionResult DeleteSU(int id) {
           
                var simpleUser = _db.Users.Find(id);
                _db.Users.Remove(simpleUser);
                _db.SaveChanges();
                return RedirectToAction("Index","Home");

        }

        [HttpGet]
        public IActionResult UpdateSU(int id)
        {

            var simpleUser = _db.Users.Find(id);
            if (simpleUser == null ) {
                return RedirectToAction("Error","Home");
            }
            return View(simpleUser);

        }

        //[HttpPost]
        //public IActionResult UpdateSU(SUViewModel suvm,int id)
        //{

        //    var simpleUser = _db.SimpleUsers.Find(id);
        //    var password = simpleUser.Password; 
        //    simpleUser = _mapper.Map<SimpleUser>(suvm);
        //    simpleUser.Password = password;

        //    if (ModelState.IsValid) {
        //        _db.SimpleUsers.Update(simpleUser);
        //        _db.SaveChanges();
        //        return RedirectToAction("HomePage","SimpleUser");
        //    }
        //    return View(suvm);
        //}
    }
}
