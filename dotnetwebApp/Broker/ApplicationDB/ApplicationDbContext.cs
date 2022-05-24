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

        public DbSet<Tags> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                 modelBuilder.Entity<User>().HasDiscriminator<string>("type")
                .HasValue<Agent>("Agent")
                .HasValue<SimpleUser>("SimpleUser");

           

                 


                modelBuilder.Entity<Tags>().Property(t => t.TagName)
               .HasMaxLength(10);

                 modelBuilder.Entity<Category>().Property(c => c.CategoryName)
                .HasMaxLength(10)
                .IsRequired();

                

                modelBuilder.Entity<User>().Property(u => u.Name)
                .HasMaxLength(20)
                .IsRequired();


                modelBuilder.Entity<User>().Property(u => u.LastName)
                .HasMaxLength(30)
                .IsRequired();


                modelBuilder.Entity<User>().Property(u => u.Email)
                .HasMaxLength(30)
                .IsRequired();


                modelBuilder.Entity<User>().Property(u => u.Telephone)
                .HasMaxLength(20)
                .IsRequired();


                modelBuilder.Entity<User>().Property(u => u.Street)
                .IsRequired();


                modelBuilder.Entity<User>().Property(u => u.City)
                .HasMaxLength(20)
                .IsRequired();


                modelBuilder.Entity<User>().Property(u => u.State)
                .HasMaxLength(20)
                .IsRequired();


                modelBuilder.Entity<Agent>().Property(a => a.AgentId)
                .IsRequired();


                modelBuilder.Entity<Agent>().Property(a => a.AccountNr)
                .IsRequired();

                

                modelBuilder.Entity<Post>().Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();

                modelBuilder.Entity<Post>().Property(p => p.Description)
                .IsRequired();

                modelBuilder.Entity<Post>().Property(p => p.Street)
                .HasMaxLength(50)
                .IsRequired();

                modelBuilder.Entity<Post>().Property(p => p.State)
                .HasMaxLength(20)
                .IsRequired();

                modelBuilder.Entity<Post>().Property(p => p.City)
                .HasMaxLength(20)
                .IsRequired();

                modelBuilder.Entity<Post>().Property(p => p.PostUserId)
                .IsRequired();

                 modelBuilder.Entity<PostCategory>().HasKey(pc => new { pc.CategoryId, pc.PostId });

                modelBuilder.Entity<PostImage>().Property(pi => pi.Type)
                .HasMaxLength(10)
                .IsRequired();

                modelBuilder.Entity<PostImage>().Property(pi => pi.ImageName)
                .IsRequired();
        }
    
    }
}
