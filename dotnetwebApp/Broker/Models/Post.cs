
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class Post
    {

        public int PostId { get; set; }
        public string Title { get; set; }
        public decimal Longtitude { get; set; }
        public decimal Latitude { get; set; }
        public string Qyteti { get; set; }
        public string Rruga { get; set; }
        public int PostalCode { get; set; }
        public bool isArchived { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Tags> tags { get; set; }
        public int? AgentID { get; set; }
        [ForeignKey("AgentID")]
        public Agent agent { get; set; }

        public virtual ICollection<CounterOffer> CounterOffers { get; set; }


    }
}
