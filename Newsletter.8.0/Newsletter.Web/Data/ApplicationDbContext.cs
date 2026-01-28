using GeniusChuck.Newsletter.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GeniusChuck.Newsletter.Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscriber>()
                .Property(s => s.RegistrationDate)
                .HasDefaultValueSql("getutcdate()")
                .HasComment("Indique la date/heure de son inscription");

            modelBuilder.Entity<CategorySubscriber>().HasKey(cs => new { cs.CategoryId, cs.SubscriberId });

            modelBuilder.Entity<Category>().Property(x => x.CreatedAt).HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Subscribers)
                .WithMany(x => x.Categories)
                .UsingEntity<CategorySubscriber>()
                .Property(s => s.SubscriptionDate)
                .HasDefaultValueSql("getutcdate()")
                .HasComment("Indique la date/heure de son inscription pour une catégorie donnée!");

            //modelBuilder.Entity<Subscriber>()
            //    .HasMany(x => x.Categories)
            //    .WithMany(x => x.Subscribers)
            //    .UsingEntity<CategorySubscriber>()
            //    .Property(s => s.SubscriptionDate)
            //    .ValueGeneratedOnAdd()
            //    .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Category>().HasData([
                new Category() { Id = 1, Name = "Sport", Description = "Vive le sport.", CreatedAt = DateTime.Now},
                new Category() { Id = 2, Name = "Culture", Description = "Vive la culture.", CreatedAt = DateTime.Now },
                new Category() { Id = 3, Name = "Politique", Description = "Vive la politique.", CreatedAt = DateTime.Now },
                new Category() { Id = 5, Name = "Jeux vidéo", Description = "Vive les jeux vidéo.", CreatedAt = DateTime.Now }
            ]);
        }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategorySubscriber> CategorySubscriber { get; set; }
    }
}
