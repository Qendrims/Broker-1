using Broker.ApplicationDB;
using Broker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Broker.Controllers
{
    public class ArchiveController : Controller
    {

        private readonly ApplicationDbContext _context;
        public ArchiveController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var archived = _context.Posts.Where(p => p.IsArchived == true).ToList();
            return View(archived);
        }
        public IActionResult Unarchive(int id)
        {
       
            var posts = _context.Posts.Where(p => p.PostId == id).FirstOrDefault();
            posts.IsArchived = !posts.IsArchived;
            _context.Posts.Update(posts);
            _context.SaveChanges();

            return RedirectToAction("Index");
            
        }
    }
}
