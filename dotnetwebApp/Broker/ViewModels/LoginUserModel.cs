using System;

namespace Broker.ViewModels
{
    public class LoginUserModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
        

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Telephone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}
