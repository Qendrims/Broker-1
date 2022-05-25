using Broker.Models;
using Microsoft.EntityFrameworkCore;

namespace Broker.ApplicationDB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<SimpleUser> SimpleUsers { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                 modelBuilder.Entity<User>().HasDiscriminator<string>("type")
                .HasValue<Agent>("Agent")
                .HasValue<SimpleUser>("SimpleUser");
        }  
    
    }
}
