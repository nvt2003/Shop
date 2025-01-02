

using AutoMapper;
using BusinessObjects;
using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class InventoryDAO
    {
        private readonly ShopDBContext _context;
        private readonly IMapper _mapper;
        public InventoryDAO(ShopDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<InventoryViewModel> GetInventories(int page, int pageSize)
        {
            var inventories = _context.Inventories.Where(i => i.DeletedAt == null).Include(i => i.Product).OrderBy(i => i.Product.Name)
                .Skip(page * pageSize).Take(pageSize).ToList();
            var inventoryViewList = _mapper.Map<List<InventoryViewModel>>(inventories);
            return inventoryViewList;
        }
        public InventoryViewModel GetInventoryById(int id)
        {
            var inventory = _context.Inventories.Include(i=>i.Product).AsNoTracking()
                .FirstOrDefault(i=>i.Id == id);
            var inventoryVM = _mapper.Map<InventoryViewModel>(inventory);
            return inventoryVM;
        }
        public InventoryDTO CreateInventory(InventoryDTO inventoryDTO)
        {
            try
            {
                Inventory inventory = _mapper.Map<Inventory>(inventoryDTO);
                _context.Inventories.Add(inventory);
                _context.SaveChanges();
                //_context.Entry(inventory).GetDatabaseValues();
                inventoryDTO.Id = inventory.Id;
                return inventoryDTO;
            }catch (Exception ex)
            {
                return new InventoryDTO();
            }
        }
        public InventoryDTO UpdateInventory(InventoryDTO inventoryDTO)
        {
            try
            {
                Inventory inventory = _mapper.Map<Inventory>(inventoryDTO);
                _context.Inventories.Update(inventory);
                _context.SaveChanges();
                return inventoryDTO;
            }
            catch (Exception ex)
            {
                return new InventoryDTO();
            }
        }
        public bool HideInventory(int id)
        {
            //try
            //{
            //    Inventory inventory = _context.Inventories.FirstOrDefault(i=>i.Id  == id);
            //    _context.Inventories.Remove(inventory);
            //    _context.SaveChanges();
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
            try
            {
                Inventory inventory = _context.Inventories.FirstOrDefault(i => i.Id == id);
                inventory.DeletedAt = DateTime.Now;
                _context.Inventories.Update(inventory);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
