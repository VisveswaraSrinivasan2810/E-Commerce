using Bhaarat_Bazaar.data;
using Bhaarat_Bazaar.models;
using Microsoft.EntityFrameworkCore;

namespace Bhaarat_Bazaar.repositories.services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BharatDbContext dbContext;

        public OrderRepository(BharatDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
               var oList = await dbContext.Orders.ToListAsync();
               return oList;
        }

        public async Task<Order> GetOrdersByIdAsync(int orderId)
        {
            var oList = await dbContext.Orders.Where(o=>o.OrderId == orderId).ToListAsync();   
            return oList.FirstOrDefault();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            var oList = await dbContext.Orders.Where(u=>u.UserId == userId).ToListAsync();
            return oList;
        }

        public async Task RemoveOrderAsync(int orderId)
        {
            var order = await dbContext.Orders.FindAsync(orderId);
            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            dbContext.Orders.Update(order);
            await dbContext.SaveChangesAsync();
        }
    }
}
