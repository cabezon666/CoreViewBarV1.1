using CoreViewBar.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreViewBar.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
            //For instance the DbContext with the appDbContext it will be used. It will pass the parameters to the base class
        {
        }

        //This part is for the EF
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(oi => new { oi.ProductID, oi.OrderID });
            modelBuilder.Entity<OrderItem>().HasOne(o => o.Order).WithMany(oi => oi.OrderItems).HasForeignKey(o => o.OrderID);
            modelBuilder.Entity<OrderItem>().HasOne(p => p.Product).WithMany(oi => oi.OrderItems).HasForeignKey(p => p.ProductID);
            base.OnModelCreating(modelBuilder);

        }
        //Tables names
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders{get;set;}
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShopBag> ShopBags { get; set; }
        public DbSet<DiscountShopBag> DiscountShopBags { get; set; }
        public DbSet<Coupon4Discount> Coupon4Discounts { get; set; }        
    }
}
