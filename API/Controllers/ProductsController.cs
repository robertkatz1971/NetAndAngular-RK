using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts() {
            var products =  await _repository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            return await _repository.GetProductByIdAsync(id);
        }

        [HttpGet("Types")]  
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes() {
            var productTypes =  await _repository.GetProductTypesAsync();
            return Ok(productTypes);
        }
        
        [HttpGet("Brands")]  
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() {
            var brands =  await _repository.GetProductBrandsAsync();
            return Ok(brands);
        }
    }
}