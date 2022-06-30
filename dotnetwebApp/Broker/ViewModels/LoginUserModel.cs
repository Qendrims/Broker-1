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
    }
}
