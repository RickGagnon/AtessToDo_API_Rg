using Microsoft.EntityFrameworkCore;
using AtessToDoAPI.Models;

namespace AtessToDoAPI.Models
{
    public class AtessTodoContext : DbContext
    {
        public AtessTodoContext(DbContextOptions<AtessTodoContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Category>().ToTable("Categories");

        }

       

        
    }
}
