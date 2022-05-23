using System.ComponentModel.DataAnnotations;

namespace BrokerApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BDay { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsAvtive { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
