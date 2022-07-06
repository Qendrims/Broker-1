using System.ComponentModel.DataAnnotations;

namespace Broker.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confrim password")]
        [Compare("Password", ErrorMessage ="Password and Confrim Password must match")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
