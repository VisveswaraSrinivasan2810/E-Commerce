using Bhaarat_Bazaar.data;
using Bhaarat_Bazaar.models;
using Microsoft.EntityFrameworkCore;

namespace Bhaarat_Bazaar.repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BharatDbContext dbContext;

        public ProductRepository(BharatDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
             var prod = await GetProductByIdAsync(id);
            if(prod != null)
            {
                dbContext.Products.Remove(prod);
                await dbContext.SaveChangesAsync();
            }
             return true;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var prodList = await dbContext.Products.ToListAsync();
            return prodList;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(int categoryId)
        {
            return await dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();        
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
           return await dbContext.Products.FirstOrDefaultAsync(x=>x.ProductId == id);
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            var searchList = await dbContext.Products.Where(x=>x.Equals(searchTerm)).ToListAsync();
            return searchList;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
    }
}
