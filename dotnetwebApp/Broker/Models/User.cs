using System;
using System.ComponentModel.DataAnnotations;

namespace Broker.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Telephone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;
        public ICollection<Post> Posts { get; set; }
    }
}
