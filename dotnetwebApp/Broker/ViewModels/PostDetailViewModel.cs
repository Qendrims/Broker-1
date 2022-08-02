using Broker.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Broker.ViewModels
{
    public class PostDetailViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public List<PostImage> Image { get; set; }=new List<PostImage>();

        public List<IFormFile> ImageUploaded { get; set; }

        public string Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? Rooms { get; set; }
        public int? BathRooms { get; set; }
        public int? Size { get; set; }
        public int? Floors { get; set; }
        public int? ApartmentFlor { get; set; }

        public double Price { get; set; }
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }



        public string GetImageName(Post postImages,string imageName) 
        {

            foreach(PostImage postImage in postImages.Images)
            {
                if(postImage.ImageName == imageName)
                {
                    return postImage.ImageName;
                }

            }
            return null;
        }

    }
}
