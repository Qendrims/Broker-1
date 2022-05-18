using Broker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Broker.Controllers
{
    public class PostController : Controller
    {
        public IActionResult PostPage(string category)
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
            List<PostViewModel> postFilter = posts.Where(p => p.Category == category).ToList();
            if (category != null)
                return View(postFilter);
            else return View(posts);
        }
    }
}
