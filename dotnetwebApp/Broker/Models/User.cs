using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter birthday")]
        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

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
        public bool IsActive { get; set; } = true;


        public bool IsDeleted { get; set; } = false;
        public ICollection<Post> Posts { get; set; }


    }
}