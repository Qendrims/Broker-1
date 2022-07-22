using Broker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Broker.ApplicationDBContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public ApplicationDbContext()
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<AdsPayments> AdsPaymentcs { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<TrackUser> TrackUsers { get; set; }
        public DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tags>().Property(t => t.TagName)
           .HasMaxLength(100);

            modelBuilder.Entity<Category>().Property(c => c.CategoryName)
           .HasMaxLength(100);

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                CategoryName = "House",
                DefaultActive = true

            },new Category
            {
                CategoryId=2,
                CategoryName = "Apartment",
                DefaultActive = false
            },new Category
            {
                CategoryId = 3,
                CategoryName = "Land",
                DefaultActive= false
            });

            modelBuilder.Entity<User>().Property(u => u.Name)
            .HasMaxLength(200)
            .IsRequired();

            modelBuilder.Entity<User>().Property(u => u.LastName)
            .HasMaxLength(300)
            .IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Email)
            .HasMaxLength(300)
            .IsRequired();


            modelBuilder.Entity<User>().Property(u => u.City)
            .HasMaxLength(200);

            modelBuilder.Entity<User>().Property(u => u.State)
            .HasMaxLength(200);

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

            

            modelBuilder.Entity<PostCategory>().HasKey(pc => new { pc.CategoryId, pc.PostId });

            modelBuilder.Entity<PostImage>().Property(pi => pi.Type)
            .HasMaxLength(10)
            .IsRequired();

            modelBuilder.Entity<PostImage>().Property(pi => pi.ImageName)
            .IsRequired();
        }

    }
}
