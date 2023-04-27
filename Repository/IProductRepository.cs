using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<Product> addProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts(IEnumerable<string>? categories, string? name, int? minPrice, int? maxPrice);
    }
}