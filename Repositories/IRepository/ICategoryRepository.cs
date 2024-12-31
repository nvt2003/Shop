
using BusinessObjects.DTOs;

namespace Repositories.IRepository
{
    public interface ICategoryRepository
    {
        List<CategoryDTO> GetAllCategories();
        List<CategoryDTO> GetCategories(int page, int pageSize);
        CategoryDTO GetCategoryById(int id);
        bool CreateCategory(CategoryDTO categoryDTO);
        bool UpdateCategory(CategoryDTO categoryDTO);
        bool DeleteCategory(int id);
    }
}
