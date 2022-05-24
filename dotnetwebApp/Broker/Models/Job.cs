using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class Job
    {
        public int Id { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public string Tip { get; set; }
        public string TakenBy { get; set; }
        public string GivenBy { get; set; }
        public int AgentId { get; set; }

        [ForeignKey("AgentId")]
        public Agent Agent { get; set; }

    }
}
