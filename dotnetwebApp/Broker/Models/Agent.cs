using System.ComponentModel.DataAnnotations;

namespace Broker.Models
{
    public class Agent : User
    {
        [Required(ErrorMessage = "Please enter AgentId")]
        public int AgentId { get; set; }
        public double Income { get; set; }
        public double Outcome { get; set; }
        public long AccountNr { get; set; }

    }
}
