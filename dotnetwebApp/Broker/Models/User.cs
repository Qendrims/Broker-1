using System;

namespace Broker.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Ditelindja { get; set; }
        public DateTime CreatedAt = DateTime.Now;
        public int PostalCode { get; set; }
        public string Rruga { get; set; }
        public string Qyteti { get; set; }



    }
}
