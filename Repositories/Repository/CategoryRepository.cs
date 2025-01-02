

using BusinessObjects.DTOs;
using DataAccess.DAO;
using Repositories.IRepository;

namespace Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDAO _categoryDAO;
        public CategoryRepository(CategoryDAO categoryDAO)
        {
            _categoryDAO = categoryDAO;
        }
        public CategoryDTO CreateCategory(CategoryDTO categoryDTO)
        {
            return _categoryDAO.CreateCategory(categoryDTO);
        }

        public bool HideCategory(int id)
        {
            return _categoryDAO.HideCategory(id);
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return _categoryDAO.GetAllCategories();
        }

        public List<CategoryDTO> GetCategories(int page, int pageSize)
        {
            return _categoryDAO.GetCategories(page, pageSize);
        }

        public CategoryDTO GetCategoryById(int id)
        {
            return _categoryDAO.GetCategoryById(id);
        }

        public CategoryDTO UpdateCategory(CategoryDTO categoryDTO)
        {
            return _categoryDAO.UpdateCategory(categoryDTO);
        }
    }
}
