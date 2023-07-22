using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Data
{
    public class OnlineShopContext : DbContext
    {
        public OnlineShopContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailProduct>().HasNoKey();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<DetailProduct> DetailProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}