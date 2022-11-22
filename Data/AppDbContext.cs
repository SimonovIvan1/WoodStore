using Microsoft.EntityFrameworkCore;
using WoodStore.Models;
using WoodStore.Models.Entity;

namespace WoodStore.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<GoodsInOrder> GoodsInOrder {get; set;}
        public DbSet<Courier> Courier { get; set; }
        public DbSet<Picker> Picker { get; set; }
        public DbSet<SalesManager> SalesManager { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
