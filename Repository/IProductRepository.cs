using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>?> getProducts(string? name, string? author, int? minPrice, int? maxPrice, int?[] categoryID, int? id, int? start, int? limit, string? orderby, string? dir);
    }
}