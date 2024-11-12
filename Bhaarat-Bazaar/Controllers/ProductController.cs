using Bhaarat_Bazaar.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bhaarat_Bazaar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _prodRepository;
        public ProductController(IProductRepository prodRepository)
        {
            _prodRepository = prodRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
           var prods = await _prodRepository.GetAllProductsAsync();
            return Ok(prods);   
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetProductByCategory([FromBody] int categoryId)
        {
            var prod = await _prodRepository.GetProductByCategory(categoryId);
            if(prod == null)
            {
                return NotFound("Product not found in the database");
            }
            return Ok(prod);
        }
    }
}
