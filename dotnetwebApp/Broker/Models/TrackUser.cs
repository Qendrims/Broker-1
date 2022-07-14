using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class TrackUser
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string IP { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
