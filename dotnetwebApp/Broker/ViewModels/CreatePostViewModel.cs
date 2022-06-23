using Broker.Models;
using System.Collections.Generic;

namespace Broker.ViewModels
{
    public class CreatePostViewModel
    {
        public List<Category> categories { get; set; }
        public List<Agent> agents { get; set; }
        public Post post { get; set; }
    }
}
