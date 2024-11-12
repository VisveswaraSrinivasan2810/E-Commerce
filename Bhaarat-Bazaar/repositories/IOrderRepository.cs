using Bhaarat_Bazaar.models;

namespace Bhaarat_Bazaar.repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrdersByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order> AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task RemoveOrderAsync(int orderId);
    }
}
