using Broker.Models;
using System.Collections.Generic;

namespace Broker.ViewModels
{
    public class FilteredPostViewModel
    {
        public List<Pos t> FilteredPosts { get; set; }
        public List<Category> FilteredCategories { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
    }
}
