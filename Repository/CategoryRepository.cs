using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        Store214104465Context _store214104465;

        public CategoryRepository(Store214104465Context store214104465)
        {
            this._store214104465 = store214104465;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _store214104465.Categories.ToListAsync();
            return categories;
        }
        public async Task<Category> addCategory(Category category)
        {
            await _store214104465.Categories.AddAsync(category);
            await _store214104465.SaveChangesAsync();
            return category;
        }
    }
}
