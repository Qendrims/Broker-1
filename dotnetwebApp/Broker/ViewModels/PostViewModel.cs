using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Broker.ViewModels
{
    public class PostViewModel 
    {
        public string Title { get; set; }

        public List<IFormFile> Image { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        public int OwnerId { get; set; }
        public string City { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    
}
