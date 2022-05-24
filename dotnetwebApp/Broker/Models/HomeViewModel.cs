using System.Collections.Generic;

namespace Broker.Models
{
    public class HomeViewModel
    {
        public List<PostViewModel> posts { get; set; }
        public List<string> categories { get; set; }
    }
}
