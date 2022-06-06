using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class Tags
    {
     
        [Key]
        public int TagsId { get; set; }
        public string TagName { get; set; }

        public int? ForPost { get; set; }

        [ForeignKey("ForPost")]

        public Post Post { get; set; }
    }
}
