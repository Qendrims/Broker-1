using Broker.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerApp.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }
        public long Size { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }  

    }
}
