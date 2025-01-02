

using BusinessObjects.DTOs;
using DataAccess.DAO;
using Repositories.IRepository;

namespace Repositories.Repository
{
    public class InventoryRepository:IInventoryRepository
    {
        private readonly InventoryDAO _inventoryDAO;
        public InventoryRepository(InventoryDAO inventoryDAO)
        {
            _inventoryDAO = inventoryDAO;
        }

        public InventoryDTO CreateInventory(InventoryDTO inventoryDTO)
        {
            return _inventoryDAO.CreateInventory(inventoryDTO);
        }

        public bool HideInventory(int id)
        {
            return _inventoryDAO.HideInventory(id);
        }

        public List<InventoryViewModel> GetInventories(int page, int pageSize)
        {
            return _inventoryDAO.GetInventories(page, pageSize);
        }

        public InventoryViewModel GetInventoryById(int id)
        {
            return _inventoryDAO.GetInventoryById(id);
        }

        public InventoryDTO UpdateInventory(InventoryDTO inventoryDTO)
        {
            return _inventoryDAO.UpdateInventory(inventoryDTO);
        }
    }
}
