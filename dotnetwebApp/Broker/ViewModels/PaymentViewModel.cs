using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.ViewModels
{
    public class PaymentViewModel
    {
        public string Token { get; set; }
        public double Total { get; set; }
        public string Email { get; set; }

    }
}
