using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrokerApp.Models;

namespace Broker.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsArchived { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime MeetingDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public int? PostUserId { get; set; }
        [ForeignKey("PostUserId")]
        public User User { get; set; }
        
        public int? TakenBy { get; set; }
        [ForeignKey("TakenBy")]
        public Agent Agent { get; set; }

        public virtual ICollection<PostCategory> PostCategories { get; set; }
        public bool IsDeleted { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public virtual ICollection<PostImage> Images { get; set; }



    }
}
