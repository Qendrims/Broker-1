using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class PostImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
