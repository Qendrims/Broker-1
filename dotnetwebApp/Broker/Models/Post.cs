using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
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
        
    }
}
