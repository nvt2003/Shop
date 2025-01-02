
using BusinessObjects.DTOs;

namespace Repositories.IRepository
{
    public interface ICategoryRepository
    {
        List<CategoryDTO> GetAllCategories();
        List<CategoryDTO> GetCategories(int page, int pageSize);
        CategoryDTO GetCategoryById(int id);
        CategoryDTO CreateCategory(CategoryDTO categoryDTO);
        CategoryDTO UpdateCategory(CategoryDTO categoryDTO);
        bool HideCategory(int id);
    }
}
