using Broker.ApplicationDB;
using Broker.Services.Interface;
using Broker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Broker.Component
{
    public class RelatedPostsViewComponent:ViewComponent
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _Dbcontext;

        public RelatedPostsViewComponent(IUserService userService, ApplicationDbContext applicationDb)
        {
            _userService = userService;
            _Dbcontext = applicationDb;

        }
        
        public async Task<IViewComponentResult> InvokeAsync(int id, int pg = 1) {
            this._userService.TrackUser();
            FilteredPostViewModel posts = new FilteredPostViewModel();
            posts.FilteredPosts = new List<Models.Post>();

            var relatedPosts = _Dbcontext.Posts.Where(p => p.PostCategories.Any(pc => pc.CategoryId == id)).Include(x => x.Images).Include(x => x.PostCategories).ToArray();

            for(int i=0;i<relatedPosts.Length;i++){
                Random rnd= new Random();
                int j = rnd.Next(0,relatedPosts.Length);

                
                    while (posts.FilteredPosts.Contains(relatedPosts[j])) {
                         j = rnd.Next(0, relatedPosts.Length);
                    }


                posts.FilteredPosts.Add(relatedPosts[j]);

                if (i == 4) {
                    break;
                }
            }

            return View(posts);
        }
    }
}
