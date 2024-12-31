

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
        public bool CreateCategory(CategoryDTO categoryDTO)
        {
            return _categoryDAO.CreateCategory(categoryDTO);
        }

        public bool DeleteCategory(int id)
        {
            return _categoryDAO.DeleteCategory(id);
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

        public bool UpdateCategory(CategoryDTO categoryDTO)
        {
            return _categoryDAO.UpdateCategory(categoryDTO);
        }
    }
}
