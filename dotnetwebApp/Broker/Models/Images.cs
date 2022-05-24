using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post post { get; set; }

      }
}
