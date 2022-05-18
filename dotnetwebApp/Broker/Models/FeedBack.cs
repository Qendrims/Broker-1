using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? SentBy { get; set; }
        [ForeignKey("SentBy")]
        public User User { get; set; }
        public int? SentTo { get; set; }
        [ForeignKey("SentTo")]
        public Agent Agent { get; set; }
        
    }
}
