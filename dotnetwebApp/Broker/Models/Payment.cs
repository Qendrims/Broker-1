using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int? SentBy { get; set; }
        [ForeignKey("SentBy")]
        public User User { get; set; }
        public int? SentTo { get; set; }
        [ForeignKey("SentTo")]
        public Agent Agent { get; set; }
        public double Price { get; set; }
        public double Tip { get; set; }
        public bool PaymentFinished { get; set; }
    }
}
