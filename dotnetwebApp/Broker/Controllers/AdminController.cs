﻿using Broker.ApplicationDB;
using Broker.Models;
using Broker.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Broker.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext _db;
        // GET: AdminController]
        public AdminController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public ActionResult Index()

        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        public IActionResult AllPosts()
        
        {
            AdminAllUsersAndPosts viewModel = new AdminAllUsersAndPosts();

            viewModel.Posts = this._db.Posts.ToList();
            viewModel.Users = this._db.Users.ToList();
                
           return View(viewModel);
        }
        
       
    }
}
