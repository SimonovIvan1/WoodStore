using Microsoft.EntityFrameworkCore;
using WoodStore.Models;

namespace WoodStore.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Goods> Goods { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
