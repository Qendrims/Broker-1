using Broker.ApplicationDB;
using Broker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Controllers
{

    public class PaymentController : Controller
    {
    private readonly ApplicationDbContext _db;
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Charge(int id,PaymentViewModel data)
        {
            var customers = new Stripe.CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = data.Email,
                Source = data.Token

            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = Convert.ToInt32(data.Total),
                Description = "Test Payment",
                Currency = "usd",
                Customer = customer.Id,
                ReceiptEmail=data.Email,
                Metadata=new Dictionary<string, string>()
                {
                    {"OrderId","111" },
                    {"Postcode","LEE111" },
                    
                }
            });

            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                var sponsorePost = _db.Posts.Where(p => p.PostId == id).FirstOrDefault();
                sponsorePost.IsSponsored = true;
                _db.Posts.Update(sponsorePost);
                _db.SaveChanges();
                return View();
            }
            else
            {
                return View();
            }
            
        }

    }
}
