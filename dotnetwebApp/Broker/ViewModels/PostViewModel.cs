using Broker.Models;
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
        public int OwnerId { get; set; } = 2;
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int ZipCode { get; set; }
        public List<int> CategoryId { get; set; }
    }
    
}
