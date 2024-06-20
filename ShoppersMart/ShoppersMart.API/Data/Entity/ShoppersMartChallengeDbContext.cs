using ShoppersMart.API.Data.Entity.DbSet;
using Microsoft.EntityFrameworkCore;

namespace ShoppersMart.API.Data.Entity;
public class ShoppersMartChallengeDbContext: DbContext
{
    public ShoppersMartChallengeDbContext(DbContextOptions<ShoppersMartChallengeDbContext> options)
          : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}

