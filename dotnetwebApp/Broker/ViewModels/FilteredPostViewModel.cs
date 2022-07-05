using Broker.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Broker.ViewModels
{
    public class FilteredPostViewModel
    {
        public List<Post> FilteredPosts { get; set; }
        public List<Category> FilteredCategories { get; set; }
        public List<string> Cities { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public ICollection<PostImage> Image { get; set; } = new List<PostImage>();

        public ICollection<IFormFile> ImageUploaded { get; set; }
        public string minPrice { get; set; }
    }
}
