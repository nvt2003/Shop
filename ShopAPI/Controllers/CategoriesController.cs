using AutoMapper;
using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;

namespace ShopAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            List<CategoryDTO> categories = _categoryRepository.GetAllCategories();
            if (categories == null)
            {
                return NoContent();
            }
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var category = _categoryRepository.CreateCategory(categoryDTO);
                if(category.Id!=null)
                {
                    return Ok(categoryDTO);
                }
                else
                {
                    return BadRequest("Cannot create!");
                }
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (id != categoryDTO.Id)
                {
                    return BadRequest("Id doesn't match!");
                }
                CategoryDTO updateCategory = _categoryRepository.GetCategoryById(id);
                if (updateCategory == null)
                {
                    return NotFound("Not found category with id " + id);
                }
                updateCategory = categoryDTO;
                var category = _categoryRepository.UpdateCategory(updateCategory);
                if(category.Id!=null)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Cannot update!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var category = _categoryRepository.GetCategoryById(id);
                if (category == null)
                {
                    return NotFound();
                }
                if (_categoryRepository.HideCategory(id))
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Cannot delete!");
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message) ;
            }
        }
    }
}
