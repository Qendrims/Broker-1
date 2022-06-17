namespace Broker.Models
{
    public class AdsPayments
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int PostId { get; set; }

        public int HowManyPeople { get; set; }

        public double Price { get; set; }
        public int Days { get; set; }

        public string NameOnCard { get; set; }

        private double CreditCardNumber { get; set; }
        private string ExpMonth { get; set; }
        private int ExpYear { get; set; }
        private int CVV { get; set; }
        public double TotalPayment { get; set; }
        public bool ProceedToCheckOut { get; set; } = true;


    }
}
