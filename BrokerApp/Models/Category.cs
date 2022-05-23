using System.ComponentModel.DataAnnotations;

namespace BrokerApp.Models
{
    public class Category
    {
        [Key]
        public int CategorytId { get; set; }
        public string CategoryName { get; set; }
    }
}
