using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;

namespace OnlineShop.DB.Context
{
    public class OnlineShopDB : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public OnlineShopDB(DbContextOptions<OnlineShopDB> options) : base(options) { }
    }
}
