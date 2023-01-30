using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDatabaseContext _dbContext;
        public ProductRepository(MyDatabaseContext myDatabaseContext)
        {
            _dbContext = myDatabaseContext;
        }
        public async Task<IEnumerable<Product>?> getProducts(string? name, string? author, int? minPrice, int? maxPrice, int?[] categoryID, int? start, int? limit, string? orderby, string? dir)
        {
            var query = _dbContext.Products.Where(product =>
            (name == null ? true : (product.Name.Contains(name)))
            &&(author == null ? true : (product.Author.Contains(author)))
            && (minPrice == null ? true : (product.Price >= minPrice))
            && (maxPrice == null ? true : (product.Price <= maxPrice))
            && ((categoryID.Length == 0) ? true : categoryID.Contains(product.CategoryId))
            );
            IEnumerable<Product>? products = await query.ToArrayAsync();
            return products.Count() < 1 ? null : products;
        }
    }
}

