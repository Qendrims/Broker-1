using Broker.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.ViewModels
{
    public class UserEditViewModel:IdentityUser
    {
        [Required]
        [Display(Name = "EmailAddress")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Name should not be null")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }
        
       

    }
}
