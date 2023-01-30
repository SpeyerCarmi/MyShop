using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       
       
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpGet]
        public async Task<IEnumerable<Product>> getProducts([FromQuery] string? name, [FromQuery] string? author, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryID, [FromQuery] int? start, [FromQuery] int? limit, [FromQuery] string? orderby, [FromQuery] string? dir)
        {
            return await _productService.getProducts(name, author, minPrice, maxPrice, categoryID, start, limit, orderby, dir);

        }
    }
}
