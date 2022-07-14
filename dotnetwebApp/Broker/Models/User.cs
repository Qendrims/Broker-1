using Broker.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Broker.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage ="Name should not be null")]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Birthday is required")]
        public DateTime Birthday{ get; set; }
    
        [Required(ErrorMessage = "ZipCode is required")]
        public int ZipCode { get; set; }
    }
}
