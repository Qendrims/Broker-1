using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class PostViewModel
    {

        public List<IFormFile> Image { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public List<string> AgentsInvited{ get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; } = 0;
        public bool IsArchived { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime MeetingDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string PostUserId { get; set; }
        [ForeignKey("PostUserId")]
        public User User { get; set; }


        public virtual ICollection<PostCategory> PostCategories { get; set; }


        public List<Category> categories { get; set; }
    }
}
