﻿using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        Store214087579Context _store214087579;

        public ProductRepository(Store214087579Context store214104465)
        {
            this._store214087579 = store214104465;
        }
        public async Task<IEnumerable<Product>> GetProducts(IEnumerable<string>? categories, string? name, int? minPrice, int? maxPrice)
        {
            return await _store214087579.Products.Include(p => p.Category).Where(p =>
            ( categories.Count()==0?true: !categories.Contains(p.Category.CategoryName)) &&//categories.Count() == 0 ? false :
                (name == null || p.ProductName.Contains(name)) && 
                (minPrice == null || p.Price >= minPrice) && 
            (maxPrice == null || p.Price <= maxPrice)

                ).OrderBy(p => p.Price).ToListAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            Product? product = await _store214087579.Products.FindAsync(id);//.Include(p => p.Category);
            return product != null ? product : null;
        }
        public async Task<Product> addProduct(Product product)
        {
            await _store214087579.Products.AddAsync(product);
            await _store214087579.SaveChangesAsync();
            return product;
        }
    }
}
