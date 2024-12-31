

using AutoMapper;
using BusinessObjects;
using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class CategoryDAO
    {
        private readonly ShopDBContext _context;
        private readonly IMapper _mapper;
        public CategoryDAO(ShopDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<CategoryDTO> GetAllCategories()
        {
            var categories = _context.Categories.Where(c=>c.DeleteAt==null).ToList();
            var categoryDtos = _mapper.Map<List<CategoryDTO>>(categories);
            return categoryDtos;
        }

        public List<CategoryDTO> GetCategories(int page, int pageSize)
        {
            var categories = _context.Categories.Where(c=>c.DeleteAt==null).OrderBy(c=>c.Name).Skip(page*pageSize).Take(pageSize).ToList();
            var categoryDtos = _mapper.Map<List<CategoryDTO>>(categories);
            return categoryDtos;
        }
        public CategoryDTO GetCategoryById(int id)
        {
            var category = _context.Categories.AsNoTracking()
                .FirstOrDefault(c=>c.Id == id);
            var categoryDto = _mapper.Map<CategoryDTO>(category);
            return categoryDto;
        }
        public bool CreateCategory(CategoryDTO categoryDTO)
        {
            try
            {
                Category addCategory = _mapper.Map<Category>(categoryDTO);
                _context.Categories.Add(addCategory);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateCategory(CategoryDTO categoryDTO)
        {
            try
            {
                Category updateCategory = _mapper.Map<Category>(categoryDTO);
                _context.Categories.Update(updateCategory);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteCategory(int id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(c => c.Id == id);
                category.DeleteAt = DateTime.Now;
                _context.Categories.Update(category);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
