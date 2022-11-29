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
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Picker> Picker { get; set; }
        public DbSet<SalesManager> SalesManager { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>(builder =>
            {
                builder.ToTable("Client")
                    .HasKey(k => k.Id);

                builder.Property(k => k.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");

                builder.Property(k => k.Name)
                    .HasColumnName("Name");

                builder.Property(k => k.Address)
                    .HasColumnName("Address");

                builder.Property(k => k.Comment)
                   .HasColumnName("Comment");

                builder.Property(k => k.PhoneNumber)
                   .HasColumnName("PhoneNumber");
            });

            modelBuilder.Entity<Delivery>(builder =>
            {
                builder.ToTable("Delivery")
                    .HasKey(k => k.Id);

                builder.Property(k => k.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");

                builder.Property(k => k.Name)
                    .HasColumnName("Name");

                builder.Property(k => k.Telephone)
                    .HasColumnName("Telephone");

                builder.Property(k => k.CarNumber)
                    .HasColumnName("CarNumber");
            });

            modelBuilder.Entity<Goods>(builder =>
            {
                builder.ToTable("Goods")
                    .HasKey(k => k.Id);

                builder.Property(k => k.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");

                builder.Property(k => k.Name)
                    .HasColumnName("Name");

                builder.Property(k => k.Material)
                    .HasColumnName("Material");

                builder.Property(k => k.Size)
                   .HasColumnName("Size");

                builder.Property(k => k.UnitPrice)
                   .HasColumnName("UnitPrice");

                builder.Property(k => k.ProviderId)
                  .HasColumnName("ProviderId");
            });

            modelBuilder.Entity<GoodsInOrder>(builder =>
            {
                builder.ToTable("GoodsInOrder")
                    .HasKey(k => k.Id);

                builder.Property(k => k.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");

                builder.Property(k => k.OrderId)
                    .HasColumnName("OrderId");

                builder.Property(k => k.GoodsId)
                    .HasColumnName("GoodId");

                builder.Property(k => k.GoodCount)
                   .HasColumnName("GoodCount");
            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("Order")
                    .HasKey(k => k.Id);

                builder.Property(k => k.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");

                builder.Property(k => k.Date)
                    .HasColumnName("Date");

                builder.Property(k => k.Price)
                  .HasColumnName("Price");

                builder.Property(k => k.ClientsId)
                    .HasColumnName("ClientsId");

                builder.Property(k => k.DeliveryId)
                  .HasColumnName("DeliveryId");

                builder.Property(k => k.PickerId)
                   .HasColumnName("PickerId");

                builder.Property(k => k.SalesManagerId)
                   .HasColumnName("SalesManagerId");

            });

            modelBuilder.Entity<Picker>(builder =>
            {
                builder.ToTable("Picker")
                    .HasKey(k => k.Id);

                builder.Property(k => k.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");

                builder.Property(k => k.FullName)
                    .HasColumnName("FullName");

                builder.Property(k => k.Telephone)
                    .HasColumnName("Telephone");

            });

            modelBuilder.Entity<Provider>(builder =>
            {
                builder.ToTable("Provider")
                    .HasKey(k => k.Id);

                builder.Property(k => k.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");

                builder.Property(k => k.Name)
                    .HasColumnName("Name");

                builder.Property(k => k.Telephone)
                    .HasColumnName("Telephone");

            });

            modelBuilder.Entity<SalesManager>(builder =>
            {
                builder.ToTable("SalesManager")
                    .HasKey(k => k.Id);

                builder.Property(k => k.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");

                builder.Property(k => k.FullName)
                    .HasColumnName("FullName");

                builder.Property(k => k.Telephone)
                    .HasColumnName("Telephone");

            });
        }
    }
}
