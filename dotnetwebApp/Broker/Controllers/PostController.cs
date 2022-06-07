﻿using Broker.ApplicationDB;
using Broker.FileHelper;
using Broker.Models;
using Broker.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _Dbcontext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostController(ApplicationDbContext _context, IWebHostEnvironment _webHostEnvironment)
        {
            this._Dbcontext = _context;
            this._webHostEnvironment = _webHostEnvironment;
        }

        public IActionResult Archive(int id)
        {
            var post = _Dbcontext.Posts.Where(p => p.PostId == id).FirstOrDefault();
            post.IsArchived = true;
            _Dbcontext.Posts.Update(post);
            _Dbcontext.SaveChanges();

            return RedirectToAction("PostPage");
        }

        public IActionResult PostPage(string category, string city, int pg = 1)
        {

            FilteredPostViewModel posts = new FilteredPostViewModel();
            posts.FilteredCategories = _Dbcontext.Categories.ToList();
            posts.Cities =  _Dbcontext.Posts.Where(p=> !string.IsNullOrEmpty(p.City)).Select(m => m.City).Distinct().ToList();

            Category cat = new Category();
            if (category != null)
            {
                cat = _Dbcontext.Categories.First(c => c.CategoryName == category);
            }
            var result = _Dbcontext.Posts.Where(p => category == null || p.PostCategories.Any(pc => pc.CategoryId == cat.CategoryId))
                .Where(p => city == null || p.City.ToLower() == city.ToLower()).Where(p => p.IsArchived == false).ToList();
            posts.FilteredPosts = result;
            posts.Category = category;
            posts.City = city;

            const int postPerPage = 2;
            if (pg < 1)
                pg = 1;

            int postCount = posts.FilteredPosts.Count();
            var pager = new Pagination(postCount, pg, postPerPage);

            int postSkip = (pg - 1) * postPerPage;

            posts.FilteredPosts = posts.FilteredPosts.Skip(postSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View("PostPage", posts);
        }

        [HttpGet]
        public IActionResult Detail(int? id)
        {
            var post1 = this._Dbcontext.Posts.Where(p => p.PostId == id).Include(x => x.User).Include(x => x.Images).FirstOrDefault();

            //Image img = this._Dbcontext.Images.Where(i => i.PostId == id).FirstOrDefault();

            PostDetailViewModel postViewModel = new PostDetailViewModel();

            postViewModel.Title = post1.Title;
            postViewModel.Description = post1.Description;
            postViewModel.Price = post1.Price;
            postViewModel.OwnerId = (int)post1.PostUserId;
            postViewModel.OwnerName = post1.User.Name + " " + post1.User.LastName;
            postViewModel.Image = post1.Images.ToList();
            postViewModel.PostId = post1.PostId;

            return View(postViewModel);
        }
        [HttpGet]
        public IActionResult PostPageCreate()
        {
            CreatePostViewModel createPostView = new CreatePostViewModel();
            createPostView.categories = this._Dbcontext.Categories.ToList();
            createPostView.agents = this._Dbcontext.Agents.ToList();
            return View(createPostView);
        } 
        [HttpPost]
        public async Task<IActionResult> PostPageCreate(PostViewModel postView)
        {



            Post post = new Post();
            post.Title = postView.Title;
            post.Description = postView.Description;
            post.PostUserId = postView.PostUserId;
            post.City = postView.City;
            post.State = postView.State;
            post.Street = postView.Street;
            post.Latitude = postView.Latitude;
            post.Longitude = postView.Longitude;
            post.ZipCode = postView.ZipCode;
           

            this._Dbcontext.Posts.Add(post);
            foreach (var imageFile in postView.Image)
            {
                string fullFileName = MethodHelper.FileToBeSaved(postView.Title, imageFile).Result;

                PostImage image = new PostImage();
                image.ImageName = fullFileName;
                image.Post = post;
                image.Type = "jpg";
                this._Dbcontext.PostImages.Add(image);
            }

            foreach(var catId in postView.CategoryId)
            {
                PostCategory postCategory = new PostCategory();
                postCategory.CategoryId = catId;
                postCategory.Post = post;
            } 

            foreach(var agent in postView.AgentsInvited)
            {
                Invite inv = new Invite();
                inv.Post = post;
                inv.SentBy = post.PostUserId;
                inv.SentTo = agent;
            }

            await _Dbcontext.SaveChangesAsync();

            //File newimage = new File(postView.Title+ "- 1");
            //if (postView.Title == "")
            //{
            //    return NotFound();
            //}
            //if (postView.Image == null)
            //{
            //    return NotFound();
            //}
            //if (postView.Description == "")
            //{
            //    return NotFound();
            //}
            //if (postView.Price <= 0)
            //{
            //    return NotFound();
            //}

            //Post newPost = new Post();
            //post.Title = postView.Title;
            //post.Description = postView.Description;
            //post.Price = postView.Price;

            //this._Dbcontext.Posts.Add(newPost);
            //_Dbcontext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return View(new Post());
            }
            else
            {
                var post = this._Dbcontext.Posts.Where(x => x.PostId == id).Include(x => x.Images).FirstOrDefault();
                PostDetailViewModel postViewModel = new PostDetailViewModel();
                postViewModel.Title = post.Title;
                postViewModel.Description = post.Description;
                postViewModel.Price = post.Price;
                postViewModel.Image = post.Images.ToList();
                return View(postViewModel);

            }
        }
        public IActionResult EditView(int? id)
        {
            if (id == 0)
            {
                return View(new Post());
            }
            else
            {
                var post = this._Dbcontext.Posts.Where(x => x.PostId == id).Include(x => x.Images).FirstOrDefault();
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

            var post = this._Dbcontext.Posts.Where(x => x.PostId == id).Include(e => e.Images).FirstOrDefault();
            var ImageToDelete = post.Images.Where(x => x.PostId == id).FirstOrDefault();


            post.Title = ViewModel.Title;
            post.Description = ViewModel.Description;
            post.Price = ViewModel.Price;
            if (ViewModel.ImageUploaded != null)
                foreach (var image in ViewModel.ImageUploaded)
                {
                    string fileName = MethodHelper.FileToBeSaved(ViewModel.Title, image).Result;
                    PostImage newimage = new PostImage();
                    newimage.ImageName = fileName;
                    newimage.Post = post;
                    newimage.Type = "jpg";
                    this._Dbcontext.PostImages.Add(newimage);
                    ViewModel.Image.Add(newimage);

                }
            else
            {
                ViewModel.Image=post.Images.ToList();
            }

            ViewModel.PostId = id;

            this._Dbcontext.Update(post);
            this._Dbcontext.SaveChanges();
            return View("Detail", ViewModel);

        }
        public IActionResult Delete()
        {
            return View();
        }
        //Cdo sen qe vjen prej URl By default esjte get
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var postToDelete = this._Dbcontext.Posts.Find(id);
            var imageToDelete = this._Dbcontext.PostImages.Where(x => x.PostId == id).FirstOrDefault();
            this._Dbcontext.PostImages.Remove((PostImage)imageToDelete);
            this._Dbcontext.Posts.Remove(postToDelete);
            this._Dbcontext.SaveChanges();

            return RedirectToAction("PostPageCreate");
        }
    }
}
