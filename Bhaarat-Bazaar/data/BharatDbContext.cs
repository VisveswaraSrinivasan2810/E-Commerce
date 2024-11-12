using Bhaarat_Bazaar.models;
using Microsoft.EntityFrameworkCore;

namespace Bhaarat_Bazaar.data
{
    public class BharatDbContext:DbContext
    {
        public BharatDbContext(DbContextOptions<BharatDbContext> options): base(options)
        {
            
        }
        public  DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}
