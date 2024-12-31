using AutoMapper;
using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;

namespace ShopAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;
        public InventoriesController(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetInventory(int page, int pageSize)
        {
            var inventoryVMs = _inventoryRepository.GetInventories(page, pageSize);
            if (inventoryVMs==null)
            {
                return NoContent();
            }
            return Ok(inventoryVMs);
        }
        [HttpPost]
        public IActionResult CreateInventory([FromBody] InventoryDTO inventoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (_inventoryRepository.CreateInventory(inventoryDTO))
                {
                    return Created();
                }
                else
                {
                    return BadRequest("Cannot create!");
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateInventory(int id, [FromBody] InventoryDTO inventoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (id != inventoryDTO.Id)
                {
                    return BadRequest("Id doesn't match!");
                }
                InventoryViewModel updateInventory = _inventoryRepository.GetInventoryById(id);
                if (updateInventory == null)
                {
                    return NotFound("Not found inventory with id "+id);
                }
                if (_inventoryRepository.UpdateInventory(inventoryDTO))
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Cannot update!");
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteInventory(int id)
        {
            try
            {
                var inventory = _inventoryRepository.GetInventoryById(id);
                if(inventory== null)
                {
                    return NotFound("Not found inventory with id " + id);
                }
                if (_inventoryRepository.DeleteInventory(id))
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Cannot delete!");
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
