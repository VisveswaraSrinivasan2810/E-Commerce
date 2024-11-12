using Bhaarat_Bazaar.data;
using Bhaarat_Bazaar.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhaarat_Bazaar.repositories.services
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
            dbContext.SaveChanges();
            return product;

        }

        public async Task<bool> DeleteProductAsync(int id)
        {
           var prod = await GetProductByIdAsync(id);
            if(prod == null)
            {
                return false;
            }
           dbContext.Products.Remove(prod);
           dbContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var prodList = await dbContext.Products.Include(p=>p.Category).ToListAsync();
            return prodList;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(int categoryId)
        {
           var prodList = await dbContext.Products.Where(x=>x.CategoryId == categoryId).ToListAsync();
            return prodList;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
           var prod = await dbContext.Products.FirstOrDefaultAsync(x=>x.ProductId == id);
            return prod;
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            return await dbContext.Products.Where(p => p.Name.Contains(searchTerm) 
            || p.Description.Contains(searchTerm)).ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
    }
}
