using AutoMapper;
using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;
using System.Net.Http.Headers;

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
        [HttpDelete("{id}/Inventory/{inventoryId}")]
        public IActionResult DeleteProduct(int id, int inventoryId)
        {
            try
            {
                var product = _productRepository.GetProductById(id);
                if (product == null)
                {
                    return NotFound("Not found product with id " + id);
                }
                var inventory = _inventoryRepository.GetInventoryById(inventoryId);
                if (inventory == null)
                {
                    return NotFound("Cannot delete product becasue cannot found inventory id "+inventoryId);
                }
                _productRepository.HideProduct(id);
                _inventoryRepository.HideInventory(inventoryId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("file-image-product")]
        public async Task<IActionResult> UploadImageProduct(IFormFile imageFile)
        {
            try
            {
                var filename = ContentDispositionHeaderValue.Parse(imageFile.ContentDisposition).FileName.TrimStart('\"').TrimEnd('\"');
                string newPath = @"E:\to-delete";

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                string[] allowedImageExtensions = new string[] { ".jpg", ".jpeg", ".png" };
                if (!allowedImageExtensions.Contains(Path.GetExtension(filename)))
                {
                    return BadRequest("Only .jpg, .jpeg, .png allow!");
                }
                string newFilename = Guid.NewGuid()+Path.GetExtension(filename);
                string fullPath = Path.Combine(newPath, newFilename);
                using(var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                return Ok(new { ProfileImage = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/StaticFiles/{newFilename}" });
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
