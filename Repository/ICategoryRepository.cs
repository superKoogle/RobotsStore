using Entities;

namespace Repository
{
    public interface ICategoryRepository
    {

        public Task<IEnumerable<Category>> GetCategories();
        public Task<Category> addCategory(Category category);
    }
}