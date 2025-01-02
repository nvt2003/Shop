using AutoMapper;
using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;

namespace ShopAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductAttributesController : ControllerBase
    {
        private readonly IProductAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;
        public ProductAttributesController(IProductAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetProductAttributes(int page, int  pageSize)
        {
            var list = _attributeRepository.GetProductAttributes(page, pageSize);
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductAttributeById(int id)
        {
            var productAttribute = _attributeRepository.GetProductAttributeById(id);
            return Ok(productAttribute);
        }
        [HttpPost]
        public IActionResult CreateProductAttribute(ProductAttributeDTO productAttributeDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var productAttribute = _attributeRepository.CreateProductAttribute(productAttributeDTO);
                if (productAttribute.Id == null)
                {
                    return BadRequest("Cannot create!");
                }
                return Ok(productAttributeDTO);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProductAttribute(int id, ProductAttributeDTO productAttributeDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (id != productAttributeDTO.Id)
                {
                    return BadRequest("Id doesn't match!");
                };
                var updateProductAttribute = _attributeRepository.GetProductAttributeById(id);
                if (updateProductAttribute == null)
                {
                    return NotFound("Not found product attribute with id "+id);
                }
                updateProductAttribute = productAttributeDTO;
                var productAttribute = _attributeRepository.UpdateProductAttribute(productAttributeDTO);
                if (productAttribute.Id == null)
                    return BadRequest("Cannot update!");
                return NoContent();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProductAttribute(int id)
        {
            try
            {
                var productAttribute = _attributeRepository.GetProductAttributeById(id);
                if (productAttribute == null)
                {
                    return NotFound("Not found product attribute with id " + id);
                }
                if (_attributeRepository.HideProductAttribute(id))
                {
                    return NoContent();
                }
                return BadRequest("Cannot delete!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
