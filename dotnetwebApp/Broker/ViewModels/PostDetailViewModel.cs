using Broker.Models;
namespace Broker.ViewModels
{
    public class PostDetailViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public PostImage Image { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
       
    }
}
