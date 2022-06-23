using System.ComponentModel.DataAnnotations;

namespace Broker.Models
{
    public class Agent : User
    {
        public int AgentId { get; set; }
        public double Income { get; set; }
        public double Outcome { get; set; }


        
    }
}
