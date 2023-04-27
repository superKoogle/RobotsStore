using Entities;

namespace Business
{
    public interface ICategoryBusiness
    {
        Task<Category> addCategory(Category category);
        Task<IEnumerable<Category>> GetCategories();
    }
}