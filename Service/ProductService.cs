using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> getProducts(string? name, string? author, int? minPrice, int? maxPrice, int?[] categoryID, int? id, int? start, int? limit, string? orderby, string? dir)
        {
            IEnumerable<Product> products = await _productRepository.getProducts(name,author, minPrice, maxPrice,categoryID, id, start, limit, orderby,dir);
            return products;
        }
    }
}
