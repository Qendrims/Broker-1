using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "EmailAddress")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Birthday is required")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="0:dd\\mm\\yyyy")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage ="Phone number is required")]
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        [Compare("Password", ErrorMessage = "Password and confirmation password don't match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}
