using Broker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Broker.ApplicationDB
{
    public class ApplicationDbContext : IdentityDbContext<User>
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
        public DbSet<AdsPayments> AdsPaymentcs { get; set; }
        public DbSet<Tags> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator<string>("type")
           .HasValue<Agent>("Agent")
           .HasValue<SimpleUser>("SimpleUser");

            modelBuilder.Entity<Tags>().Property(t => t.TagName)
           .HasMaxLength(100);

            modelBuilder.Entity<Category>().Property(c => c.CategoryName)
           .HasMaxLength(100);

            modelBuilder.Entity<User>().Property(u => u.Name)
            .HasMaxLength(200)
            .IsRequired();

            modelBuilder.Entity<User>().Property(u => u.LastName)
            .HasMaxLength(300)
            .IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Email)
            .HasMaxLength(300)
            .IsRequired();


            modelBuilder.Entity<User>().Property(u => u.PhoneNumber)
            .HasMaxLength(200)
            .IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Street);


            modelBuilder.Entity<User>().Property(u => u.City)
            .HasMaxLength(200);

            modelBuilder.Entity<User>().Property(u => u.State)
            .HasMaxLength(200);

            modelBuilder.Entity<Agent>().Property(a => a.AgentId)
            .IsRequired();

            modelBuilder.Entity<Post>().Property(p => p.Title)
            .HasMaxLength(100)
            .IsRequired();

            modelBuilder.Entity<Post>().Property(p => p.Description)
            .IsRequired();

            modelBuilder.Entity<Post>().Property(p => p.Street)
            .HasMaxLength(500);

            modelBuilder.Entity<Post>().Property(p => p.State)
            .HasMaxLength(200);

            modelBuilder.Entity<Post>().Property(p => p.City)
            .HasMaxLength(200);

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
