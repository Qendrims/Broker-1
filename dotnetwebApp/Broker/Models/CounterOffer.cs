using System.Collections.Generic;

namespace Broker.Models
{
    public class CounterOffer
    {
        public int CounterOfferId { get; set; }
        public decimal CounterOfferPrice { get; set; }

        public virtual ICollection<Post> post { get; set; }

    }
}
