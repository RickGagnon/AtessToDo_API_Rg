using Microsoft.EntityFrameworkCore;

namespace AtessToDoAPI.Models
{
    public class AtessTodoContext : DbContext
    {
        public AtessTodoContext(DbContextOptions<AtessTodoContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");

        }
    }
}
