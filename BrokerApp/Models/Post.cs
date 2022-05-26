using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerApp.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public User User { get; set; }


        public int? TakenBy { get; set; }
        [ForeignKey("TakenBy")]
        public Agent Agent { get; set; }

        Image Image { get; set; }
    }
}
