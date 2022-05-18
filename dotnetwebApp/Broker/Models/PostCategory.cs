using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class PostCategory
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
