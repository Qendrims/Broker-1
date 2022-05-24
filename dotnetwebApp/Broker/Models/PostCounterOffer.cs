using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Models
{
    public class PostCounterOffer
    {
        
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post post { get; set; }
        public int CounterOfferId { get; set; }
        [ForeignKey("CounterOfferId")]
        public CounterOffer counteroffer { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Agent agent { get; set; }


    }
}
