using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class Tags
    {
        public int TagName { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post post { get; set; }

    }
}
