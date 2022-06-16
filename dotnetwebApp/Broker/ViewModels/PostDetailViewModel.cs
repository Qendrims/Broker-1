using Broker.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Broker.ViewModels
{
    public class PostDetailViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public List<PostImage> Image { get; set; }=new List<PostImage>();

        public List<IFormFile> ImageUploaded { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
