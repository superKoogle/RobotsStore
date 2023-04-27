using Entities;

namespace Business
{
    public interface IProductBusiness
    {
        Task<Product> AddProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts(IEnumerable<string>? categories, string? name, int? minPrice, int? maxPrice);
    }
}