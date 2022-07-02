using Broker.Models;
using System.Collections.Generic;

namespace Broker.ViewModels
{
    public class HomeViewModel
    {
        public List<Post> posts { get; set; }
        public Category category { get; set; }
        public bool DefaultActive { get; set; }
    }
}
