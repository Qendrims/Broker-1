namespace BrokerApp.Models
{
    public class Agent:User
    {
        public int AgentId { get; set; }
        public int SSN { get; set; }
        public long AccNumber { get; set; }
        public double InCome { get; set; }
        public double OutCome { get; set; }
    }
}
