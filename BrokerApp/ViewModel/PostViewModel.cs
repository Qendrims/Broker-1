namespace BrokerApp.ViewModels
{
    public class PostViewModel 
    {
        public string Title { get; set; }

        public List<IFormFile> Image { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
