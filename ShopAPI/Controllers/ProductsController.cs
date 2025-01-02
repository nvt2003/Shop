using AutoMapper;
using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;

namespace ShopAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;
        public ProductsController (IProductRepository productRepository,IInventoryRepository inventoryRespository, IMapper mapper)
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRespository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetProducts(int page, int pageSize)
        {
            var products = _productRepository.GetProducts(page, pageSize);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newInventory = new InventoryDTO();
                newInventory.Id = 0;
                newInventory.Quantity = 0;
                var inventory = _inventoryRepository.CreateInventory(newInventory);
                productDTO.InventoryId = inventory.Id;
                var product = _productRepository.CreateProduct(productDTO);
                if (product.Id == null)
                {
                    return BadRequest("Cannot create");
                }
                return Ok(productDTO);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductDTO productDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (id != productDTO.Id)
                {
                    return BadRequest("Id doesn't match!");
                }
                var updateProduct = _productRepository.GetProductById(id);
                if (updateProduct == null)
                {
                    return NotFound("Not found product with id " + id);
                }
                var product = _productRepository.UpdateProduct(productDTO);
                if (product.Id == null)
                {
                    return BadRequest("Cannot update!");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _productRepository.GetProductById(id);
                if (product == null)
                {
                    return NotFound("Not found product with id " + id);
                }
                _productRepository.HideProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
