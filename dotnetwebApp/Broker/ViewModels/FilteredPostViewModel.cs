using Broker.Models;
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
    }
}
