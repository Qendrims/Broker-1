using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    [Keyless]
    public class DergonCounterOffer
    {
        [Key,Column(Order=1)]
        public int postid { get; set; }
        
        public Post post { get; set; }
        [Key, Column(Order = 2)]
        public int CounterOfferId { get; set; }
        
        public CounterOffer counteroffer { get; set; }



    }
}
