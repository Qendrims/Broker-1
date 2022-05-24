using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class PostCategory
    {
        
        public int PostCategoryId { get; set; } 
        public string CategoryName { get; set; }        
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post post { get; set; }

    }
}
