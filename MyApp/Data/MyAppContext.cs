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
        // DbSet property to represent the Items table in the database
        public DbSet<Item> Items { get; set; }
    }
}
