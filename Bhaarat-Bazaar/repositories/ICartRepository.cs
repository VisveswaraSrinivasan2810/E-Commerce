using Bhaarat_Bazaar.models;

namespace Bhaarat_Bazaar.repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetProductByUserId(int userId);
        Task<CartItem> AddCartItemAsync(int userId, CartItem item); 
        Task<CartItem> UpdateCartItemAsync(int itemId, CartItem item);  
        Task RemoveCartItemAsync(int itemId);
        Task ClearCartItemAsync(int userId);

    }
}
