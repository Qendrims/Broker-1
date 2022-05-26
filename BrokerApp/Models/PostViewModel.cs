namespace BrokerApp.Models
{
    public class PostViewModel 
    {
        public string Titulli { get; set; }

        public IFormFile Image { get; set; }

        public string Descritption { get; set; }

        public double Price { get; set; }
    }
}
