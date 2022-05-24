using BrokerApp.AppDbContext;
using BrokerApp.Models;
using BrokerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Globalization;

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

            postViewModel.Title = post.Title;
            postViewModel.Description = post.Description;
            postViewModel.Price = post.Price;

            return View(postViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> PostPageCreate(IFormFile file, PostViewModel postView)
        {

            string folder = Environment.CurrentDirectory;

            Post post = new Post();
            post.Title = postView.Title;
            post.Description = postView.Description;
            post.OwnerId = postView.OwnerId;
            this._Dbcontext.Posts.Add(post);
            foreach (var imageFile in postView.Image)
            {
                string fileName = postView.Title + "-" + DateTime.Now.ToString("MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + ".jpg";
                string fullFileName = fileName.Replace(":", "-").Replace(" ", "");
                string filePath = $"{folder}\\UploadFiles\\{fullFileName}";

                //string fileName = Path.GetFileName(postView.Image[0].FileName); 
                //string webRootPath = _webHostEnvironment.WebRootPath+ "\\Uploads\\"+ fileName;

                using (var stream = System.IO.File.Create(filePath))
                {
                    await imageFile.CopyToAsync(stream);
                }

                Image image = new Image();
                image.ImageName = fullFileName;
                image.Post = post;
                image.ImageType = "jpg";
                this._Dbcontext.Images.Add(image);
            }

            await _Dbcontext.SaveChangesAsync();

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

            //Post newPost = new Post();
            //post.Title = postView.Title;
            //post.Description = postView.Description;
            //post.Price = postView.Price;

            //this._Dbcontext.Posts.Add(newPost);
            //_Dbcontext.SaveChanges();

            return RedirectToAction("AboutUs", "About");
        }

        public IActionResult Get(int id) {

            var img= this._Dbcontext.Images.Where(p => p.ImageId == id).FirstOrDefault();

            var filetype = img.ImageType;
            var folder = Environment.CurrentDirectory;
            //var content = (byte[]);
            var filename = $"{folder}\\UploadFiles\\{img.ImageName}";
            return View();//new FileContentResult(content, filename);
        }

    }
}
