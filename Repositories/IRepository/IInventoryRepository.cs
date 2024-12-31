using BusinessObjects.DTOs;

namespace Repositories.IRepository
{
    public interface IInventoryRepository
    {
        List<InventoryViewModel> GetInventories(int page, int pageSize);
        InventoryViewModel GetInventoryById(int id);
        bool CreateInventory(InventoryDTO inventoryDTO);
        bool UpdateInventory(InventoryDTO inventoryDTO);
        bool DeleteInventory(int id);
    }
}
