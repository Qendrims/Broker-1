using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class FeedBack
    {
        [Key]
        public int FeedbackId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public string SentBy { get; set; }
        [ForeignKey("SentBy")]
        public User User { get; set; }
        public string SentTo { get; set; }
        [ForeignKey("SentTo")]
        public Agent Agent { get; set; }

        

    }
}
