using System.ComponentModel.DataAnnotations;

namespace Broker.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool DefaultActive { get; set; }
       
    }
}
