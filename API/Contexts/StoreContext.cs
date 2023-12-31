using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options)
            : base(options) {}

        public DbSet<OrderLine>? OrderLines { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductCategory>? ProductCategories { get; set; }
        public DbSet<ShopOrder>? ShopOrders { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserAddress>? UserAddresses { get; set; }
        public DbSet<UserReview>? UserReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne()
                .HasForeignKey(so => so.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductCategory>().HasData(SeedData.GetProductCategories());
            modelBuilder.Entity<Product>().HasData(SeedData.GetProducts());
            modelBuilder.Entity<User>().HasData(SeedData.GetUsers());
            modelBuilder.Entity<UserAddress>().HasData(SeedData.GetUserAddresses());
            modelBuilder.Entity<UserReview>().HasData(SeedData.GetUserReviews());
            modelBuilder.Entity<ShopOrder>().HasData(SeedData.GetShopOrders());
            modelBuilder.Entity<OrderLine>().HasData(SeedData.GetOrderLines());
        }
    }
}
