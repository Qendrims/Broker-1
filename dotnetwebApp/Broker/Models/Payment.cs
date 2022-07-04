using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int? SentBy { get; set; }
        [ForeignKey("SentBy")]
        public User User { get; set; }
        public int? SentTo { get; set; }
        [ForeignKey("SentTo")]
        
        public double Price { get; set; }
        public double Tip { get; set; }
        public bool PaymentFinished { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsActive { get; set; } = true;
    }
}
