using BrokerApp.AppDbContext;
using BrokerApp.Models;
using BrokerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BrokerApp.Controllers
{
    public class PostController : Controller
    {
        private readonly PostDbContext _Dbcontext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostController(PostDbContext _context, IWebHostEnvironment _webHostEnvironment)
        {
            this._Dbcontext = _context;
            this._webHostEnvironment = _webHostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PostPageCreate()
        {        

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var post1 = this._Dbcontext.Posts.Where(p => p.PostId == id).FirstOrDefault();

            Post post = new Post();
            PostViewModel postViewModel = new PostViewModel();

            postViewModel.Title= post.Title;
            postViewModel.Description= post.Description;
            postViewModel.Price= post.Price;

            return View(postViewModel);
        }
        [HttpPost]
        public IActionResult PostPageCreate(PostViewModel postView)
        {
            string fileName = Path.GetFileName(postView.Image[0].FileName); 
            string webRootPath = _webHostEnvironment.WebRootPath+ "\\Uploads\\"+ fileName;

            using (var stream = System.IO.File.Create(webRootPath))
            {
                postView.Image[0].CopyTo(stream);
            }
            //File newimage = new File(postView.Title+ "- 1");
            if (postView.Title == "")
            {
                return NotFound();
            }
            if (postView.Image == null)
            {
                return NotFound();
            }
            if (postView.Description == "")
            {
                return NotFound();
            }
            if (postView.Price <= 0)
            {
                return NotFound();
            }

            Post post = new Post();
            post.Title = postView.Title;
            post.Description = postView.Description;
            post.Price = postView.Price;

            this._Dbcontext.Posts.Add(post);
            _Dbcontext.SaveChanges();

            return View("Index");
        }

    }
}
