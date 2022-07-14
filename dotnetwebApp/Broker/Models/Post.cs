﻿using System;
using System.Collections.Generic;
using BrokerApp.Models;
using System.Collections;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? Rooms { get; set; }
        public int? BathRooms { get; set; } 

        public int? Size { get; set; }
        public int? Floors { get; set; }
        public int? ApartmentFlor { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsArchived { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Street { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string PostUserId { get; set; }
        [ForeignKey("PostUserId")]
        public User User { get; set; }

        public virtual ICollection<PostCategory> PostCategories { get; set; }
        public bool IsDeleted { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public virtual ICollection<PostImage> Images { get; set; }



    }
}
