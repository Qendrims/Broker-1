using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public string SentBy { get; set; }
        [ForeignKey("SentBy")]
        public User User { get; set; }
        public string Comment { get; set; }
        public int Star { get; set; }
    }
}
