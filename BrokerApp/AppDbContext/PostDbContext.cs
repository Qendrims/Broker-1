using BrokerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BrokerApp.AppDbContext
{
    public class PostDbContext:DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator<string>("Discriminator")
                .HasValue<Agent>("Agent")
                .HasValue<SimpleUser>("SimpleUser");
        }
    }
}
