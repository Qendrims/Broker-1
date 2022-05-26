using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerApp.Models
{
    public class Image
    {
        public string ImageId { get; set; }
        public string ImagePath { get; set; }
        public string ImageType { get; set; }
        public long Size { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        Post post = new Post();

    }
}
