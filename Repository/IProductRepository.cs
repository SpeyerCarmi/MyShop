using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>?> getProducts(string? name, string? author, int? minPrice, int? maxPrice, int?[] categoryID, int? start, int? limit, string? orderby, string? dir,int? id);
    }
}