using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Broker.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Birthday is required")]
        public DateTime Birthday{ get; set; }
        [Required(ErrorMessage = "Country is required")]

        public string Country { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }
        [Required(ErrorMessage = "ZipCode is required")]
        public int ZipCode { get; set; }

    }
}
