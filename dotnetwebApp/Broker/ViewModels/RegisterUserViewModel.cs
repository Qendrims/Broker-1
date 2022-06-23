using System;
using System.ComponentModel.DataAnnotations;

namespace Broker.ViewModels
{
    public class RegisterUserViewModel
    {

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [MinLength(8, ErrorMessage = "Password must contain at least {1} characters")]
        [RegularExpression(@"^.*(?=.*\d)(?=.*[A-Za-z])(?=.*[.-_@%&#]{0,}).*$", ErrorMessage = "Password must contain at least one letter, number and special character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Confirmation Password")]
        [Display(Name = "Confirmation Password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmationPassword { get; set; }

        [Required(ErrorMessage = "Please enter birthday")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "Phone Number")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Please enter street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter state")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter zip code")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage ="Please select type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter AgentId")]
        public int AgentId { get; set; }
    }
}
