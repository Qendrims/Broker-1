using System.Collections.Generic;

namespace Broker.Models
{
    public class HomeViewModel
    {
        public List<Post> posts { get; set; }
        public Category category { get; set; }
    }
}
