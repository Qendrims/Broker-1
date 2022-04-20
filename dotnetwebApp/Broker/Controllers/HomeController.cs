using Broker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public JsonResult GetSomething() {
            List<PostViewModel> posts = new List<PostViewModel>();
            PostViewModel post = new PostViewModel("Home");
            PostViewModel post1 = new PostViewModel("Flat");
            PostViewModel post2 = new PostViewModel("Office");
            PostViewModel post3 = new PostViewModel("Home");
            PostViewModel post4 = new PostViewModel("Flat");
            PostViewModel post5 = new PostViewModel("Home");
            PostViewModel post6 = new PostViewModel("Flat");
            PostViewModel post7 = new PostViewModel("Flat");
            posts.Add(post);
            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post4);
            posts.Add(post5);
            posts.Add(post6);
            posts.Add(post7);
            var data = JsonConvert.SerializeObject(posts);

            return Json(data);
        }

        public IActionResult Index()
        {
            List<PostViewModel> posts = new List<PostViewModel>();
            PostViewModel post = new PostViewModel("Home");
            PostViewModel post1 = new PostViewModel("Flat");
            PostViewModel post2 = new PostViewModel("Office");
            PostViewModel post3 = new PostViewModel("Home");
            PostViewModel post4 = new PostViewModel("Flat");
            PostViewModel post5 = new PostViewModel("Home");
            PostViewModel post6 = new PostViewModel("Flat");
            PostViewModel post7 = new PostViewModel("Flat");
            posts.Add(post);
            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post4);
            posts.Add(post5);
            posts.Add(post6);
            posts.Add(post7);

            HomeViewModel HomeModel = new HomeViewModel();
            HomeModel.posts = posts;
            HomeModel.categories = new HashSet<string>(posts.Select(x => x.Category)).ToList();

            return View(HomeModel);
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
