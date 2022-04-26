using System;

namespace Broker.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Title1";
        public string Description { get; set; } = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam, excepturi voluptatem? Officia repellat praesentium error quibusdam incidunt quasi minus non nihil. Mollitia adipisci nihil illo natus cum sunt blanditiis aliquid.";

        public DateTime CreatedDate { get; set; }
        public string Category { get; set; }
        public string image { get; set; } = "grid1.jpg";
        public PostViewModel(string category)
        {
            this.Category = category;
        }
    }
}
