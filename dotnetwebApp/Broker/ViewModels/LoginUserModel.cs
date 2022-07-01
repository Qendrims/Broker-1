using System.ComponentModel.DataAnnotations;

namespace Broker.ViewModels
{
    public class LoginUserModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required]

        public string Password { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Telephone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Type { get; set; }

        public string State { get; set; }
        public int ZipCode { get; set; }
        public int AgentId { get; set; }
    }
}
