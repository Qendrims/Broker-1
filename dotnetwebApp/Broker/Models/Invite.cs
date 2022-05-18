using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class Invite
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public int? SentBy { get; set; }
        [ForeignKey("SentBy")]
        public User User { get; set; }
        public int? SentTo { get; set; }
        [ForeignKey("SentTo")]
        public Agent Agent { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime End_Date { get; set; }
    }
}
