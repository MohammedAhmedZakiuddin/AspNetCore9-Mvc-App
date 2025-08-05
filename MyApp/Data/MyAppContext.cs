using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext : DbContext
    {
        // Constructor to pass options to the base DbContext
        public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
        {
        }

        // If you need to set up relationships, constraints, or table names, this is the place to do it.
        // Leaving it empty means you rely on EF Core's default behavior.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id=4, Name="MacBook Pro", Price=2000, SerialNumberId=10}
                );

            modelBuilder.Entity<SerialNumber>().HasData(
                new Item { Id = 10, Name = "Laptop5500", ItemId=4 }
                );
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" }
                );
            base.OnModelCreating(modelBuilder);

        }

        // DbSet property to represent the Items table in the database
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
