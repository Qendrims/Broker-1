using BrokerApp.AppDbContext;
using BrokerApp.Models;
using BrokerApp.ViewModel;
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
        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                RedirectToAction("DetailAll","Post");
            }
            var post1 = this._Dbcontext.Posts.Where(p => p.PostId == id).Include(x => x.User).Include(x => x.Images).FirstOrDefault();

            //Image img = this._Dbcontext.Images.Where(i => i.PostId == id).FirstOrDefault();

            PostDetailViewModel postViewModel = new PostDetailViewModel();

            postViewModel.Title = post1.Title;
            postViewModel.Description = post1.Description;
            postViewModel.Price = post1.Price;
            postViewModel.OwnerId = (int)post1.OwnerId;
            postViewModel.OwnerName = post1.User.FirstName + " " + post1.User.LastName;
            postViewModel.Image = post1.Images.FirstOrDefault();
            postViewModel.PostId = post1.PostId;

            return View(postViewModel);
        }
        [HttpGet]
        public IActionResult PostPageCreate()
        {

            return View();
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

            return RedirectToAction("DetailAll", "Post");
        }



        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return View(new Post());
            }
            else
            {
                var post = this._Dbcontext.Posts.Where(x => x.PostId == id).Include(x=>x.Images).FirstOrDefault();
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
            var post= this._Dbcontext.Posts.Where(x=>x.PostId == id).Include(e=>e.Images).FirstOrDefault();



            post.Title = ViewModel.Title;
            post.Description = ViewModel.Description;
            ViewModel.Image = post.Images.FirstOrDefault();
            post.Price = ViewModel.Price;

            this._Dbcontext.Update(post);
            this._Dbcontext.SaveChanges();
            return View("Detail",ViewModel);

        }
        public IActionResult Delete()
        {
            return View();
        }
        //Cdo sen qe vjen prej URl By default esjte get
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var postToDelete = this._Dbcontext.Posts.Where(x => x.PostId == id).FirstOrDefault();
            this._Dbcontext.Posts.Remove(postToDelete);
            this._Dbcontext.SaveChanges();
     
            return RedirectToAction("PostPageCreate");
        }


    }
}
