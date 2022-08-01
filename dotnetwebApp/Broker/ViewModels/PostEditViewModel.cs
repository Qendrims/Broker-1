using Broker.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Broker.ViewModels
{
    public class PostEditViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public List<PostImage> Image { get; set; } = new List<PostImage>();

        public List<IFormFile> ImageUploaded { get; set; }

        public string Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? Rooms { get; set; }

        public int? BathRooms { get; set; }

        public int? Size { get; set; }
        public int? Floors { get; set; }

        [Display(Name = "Apartment Floor")]
        public int? ApartmentFlor { get; set; }

        [Display(Name = "Price")]
        public double NewPrice { get; set; }
        public double Price { get; set; }
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public int HouseNumber { get; set; }

        public string Neighbourhood { get; set; }
        public List<Review> Reviews { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }

        public List<Category> categories { get; set; }


        
    }
}
