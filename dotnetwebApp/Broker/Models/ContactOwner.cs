using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class ContactOwner
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public int ToPost { get; set; }
        [ForeignKey("ToPost")]
        public Post post { get; set; }

        public string FromUser { get; set; }
        [ForeignKey("FromUser")]
        public User user { get; set; }

    }
}
