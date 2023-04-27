using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductBusiness : IProductBusiness
    {
        IProductRepository _productRepository;
        public ProductBusiness(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> GetProducts(IEnumerable<string>? categories, string? name, int? minPrice, int? maxPrice)
        {
            return await _productRepository.GetProducts(categories, name, minPrice, maxPrice);
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }
        public async Task<Product> AddProduct(Product product)
        {
            return await _productRepository.addProduct(product);
        }

    }
}
