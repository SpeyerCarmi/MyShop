using AutoMapper;
using DTO;
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

        private readonly IMapper _mapper;

        private readonly IProductService _productService;
        public ProductController(IProductService productService, IMapper mapper)
        {

            _mapper = mapper;

            _productService = productService;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> getProducts([FromQuery] string? name, [FromQuery] string? author, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryID, [FromQuery] int? start, [FromQuery] int? limit, [FromQuery] string? orderby, [FromQuery] string? dir, [FromQuery] int? id)
        {
            IEnumerable<Product>? products = await _productService.getProducts(name, author, minPrice, maxPrice, categoryID, start, limit, orderby, dir,id);
            if (products == null)
                return NoContent();

            IEnumerable<ProductDTO> productsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return Ok(productsDTO);

        }
    }
}
