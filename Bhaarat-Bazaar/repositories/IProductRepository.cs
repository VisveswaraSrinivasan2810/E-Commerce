using Bhaarat_Bazaar.models;

namespace Bhaarat_Bazaar.repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<Product> UpdateProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductByCategory(int categoryId);
        Task<IEnumerable<Product>> SearchProductsAsync(string  searchTerm);
    }
}
